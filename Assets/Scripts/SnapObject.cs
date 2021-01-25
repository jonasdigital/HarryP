using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapObject : MonoBehaviour
{
    [SerializeField] private GameObject SnapLocation;

    [SerializeField] private GameObject basket;

    public bool isSnapped;

    private bool objectSnapped;

    private bool grabbed;

    // Update is called once per frame
    //void Update()
    //{
    //    grabbed = GetComponent<XRBaseInteractable>().isSelected;
    //    objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;

    //    if (objectSnapped == true)
    //    {
    //        GetComponent<Rigidbody>().isKinematic = true;
    //        transform.SetParent(basket.transform);
    //        isSnapped = true;
    //    }

    //    if (objectSnapped == false && grabbed == false)
    //    {
    //        GetComponent<Rigidbody>().isKinematic = false;
    //    }

    //}

    public void Snap()
    {
        grabbed = GetComponent<XRBaseInteractable>().isSelected;
        objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;

        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(basket.transform);
            isSnapped = true;
        }

        if (objectSnapped == false && grabbed == false)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }



}
