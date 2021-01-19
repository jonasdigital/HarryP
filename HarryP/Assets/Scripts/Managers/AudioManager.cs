// @Description:
// This script is responsible for playing sound whenever the Player
// hovers over or clicks a button on the Menu UI or ingame menu UI
// with the ray interactor.


using UnityEngine;

namespace _Project_Master.Scripts.Managers
{
    //-------------------------------------------------------------------------
    public class AudioManager : MonoBehaviour
    {
		#region Private Serializable Fields

		[Header("Configuration")]
		[SerializeField] private AudioClip _onClickClip = null;
		[SerializeField] private AudioClip _onHoverClip = null;
		
		#endregion
        
        
        #region Private Fields

        private AudioSource _audioSource = null;
		
		#endregion
        
		
        #region Unity Methods
        
        //-------------------------------------------------
        private void Start()
        {
	        _audioSource = GetComponent<AudioSource>();

#if UNITY_EDITOR
	        ValidateComponents();
#endif
        }

		
		#endregion


		#region Private Methods

		//-------------------------------------------------
		private void ValidateComponents()
		{
			if (!_audioSource)
				Debug.LogError("AudioSource is NULL.");
		}

		#endregion
        
        
        #region Public Methods

        //-------------------------------------------------
        public void OnClickPlaySound()
        {
	        if (_onClickClip)
		        _audioSource.PlayOneShot(_onClickClip);
        }
        
        //-------------------------------------------------
        public void OnHoverPlaySound()
        {
	        if (_onHoverClip)
		        _audioSource.PlayOneShot(_onHoverClip);
        }

		#endregion
    }
}