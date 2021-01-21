using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHolder : MonoBehaviour
{
    public GameObject Mushroom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            Mushroom.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Mushroom)
        {
            Mushroom.transform.parent = null;
        }
    }

}
