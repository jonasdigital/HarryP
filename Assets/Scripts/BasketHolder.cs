using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHolder : MonoBehaviour
{
    [SerializeField] private GameObject Mushroom;

    
    // Turn this collider into a trigger on startup
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            other.transform.parent = transform;

            other.attachedRigidbody.useGravity = false;
            //Mushroom.transform.parent = transform;
            //if (other.attachedRigidbody)
            //{
            //    other.attachedRigidbody.useGravity = false;
            //}

            
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == Mushroom)
    //    {
           
    //        Mushroom.transform.parent = null;
    //    }
        
    //}

}
