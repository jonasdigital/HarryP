using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;



public class SnapToLocation : MonoBehaviour
{
    
    private bool grabbed;

    private bool insideSnapZone;

    public bool Snapped;

    [SerializeField] private GameObject Mushroom;
    [SerializeField] private GameObject SnapRotationReference;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == Mushroom.name)
        {
            insideSnapZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == Mushroom.name)
        {
            insideSnapZone = false;
        }
    }

    void SnapObject()
    {
        if(grabbed == false && insideSnapZone == true)
        {
            Mushroom.gameObject.transform.position = transform.position;
            Mushroom.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
    }
    // Start is called before the first frame update
   //void Start()
   // {
        
   // } 
   //isSelected
   //OnSelectEntered


    // Update is called once per frame
    void Update()
    {
        grabbed = Mushroom.GetComponent<XRBaseInteractable>().isSelected;
        SnapObject();
    }
}
