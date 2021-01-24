// @Description:
// This script is responsible registering movement input from the controllers,
// moving the Player and syncing the CharacterController's capsule collider's
// height with the position of the XR Camera (the Player's head). This will
// prevent the Player from moving through gameObjects irregardless of height
// and allows for crouching behaviour.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace _Project_Zaid.Scripts.Player
{
    //-------------------------------------------------------------------------
    public class MovementProvider : LocomotionProvider
    {
        #region Private Serialized Fields

        [Header("Configuration")]
        [SerializeField] private float _moveSpeed = 2.5f;
        [SerializeField] private float _gravityModifier = 4.0f;
        [Space]
        [SerializeField] private float _characterMinHeight = 1.0f;
        [SerializeField] private float _characterMaxHeight = 2.0f;
        [Space]
        [SerializeField] private List<XRController> _controllers = null;

        

        #endregion


        #region Private Fields

        private CharacterController _characterController = null;
        private GameObject _cameraAsHead = null;

        #endregion
        

        #region Unity Methods

        //-------------------------------------------------
        protected override void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _cameraAsHead = GetComponent<XRRig>().cameraGameObject;
        }

        //-------------------------------------------------
        private void Start()
        {
            ComputeCharacterControllerCenter();
        }
        
        //-------------------------------------------------
        private void FixedUpdate()
        {
            ComputeCharacterControllerCenter();
            RegisterInputFromControllers();
            ApplyGravity();
        }

        #endregion


        #region Private Methods

        //-------------------------------------------------
        private void ComputeCharacterControllerCenter()
        {
            float headHeight = Mathf.Clamp(
                value: _cameraAsHead.transform.localPosition.y,
                min: _characterMinHeight, 
                max: _characterMaxHeight);
            
            _characterController.height = headHeight;
            
            Vector3 newCenter = Vector3.zero;
            newCenter.y = _characterController.height / 2;
            newCenter.y += _characterController.skinWidth;
            
            newCenter.x = _cameraAsHead.transform.localPosition.x;
            newCenter.z = _cameraAsHead.transform.localPosition.z;
            
            _characterController.center = newCenter;
        }
        
        //-------------------------------------------------
        private void RegisterInputFromControllers()
        {
            foreach (XRController controller in _controllers)
            {
                if (controller.enableInputActions)
                {
                    RegisterAndComputeMovementInput(controller.inputDevice);
                }
            }
        }
        
        //-------------------------------------------------
        private void RegisterAndComputeMovementInput(InputDevice device)
        {
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            {
                Move(position);
                
            }
        }
        
        //-------------------------------------------------
        private void Move(Vector2 position)
        {
            Vector3 direction = new Vector3(position.x, 0, position.y);
            Vector3 headRotation = new Vector3(0, _cameraAsHead.transform.eulerAngles.y, 0);
            
            direction = Quaternion.Euler(headRotation) * direction;
            
            Vector3 movement = direction * _moveSpeed;
            _characterController.Move(movement * Time.deltaTime);
        }
        
        //-------------------------------------------------
        private void ApplyGravity()
        {
            Vector3 gravity = new Vector3(0, Physics.gravity.y * _gravityModifier, 0);
            gravity.y *= Time.deltaTime;
            _characterController.Move(gravity * Time.deltaTime);
        }

        #endregion
    }
}
