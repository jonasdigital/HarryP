using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    private bool cube1;
    private bool cube2;
    private bool cube3;
    public MushroomSpawner svampar;
    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Grabbable"))
        {
            cube1 = true;
        }

        if (collision.gameObject.CompareTag("WitchWater"))
        {
            cube2 = true;
        }

        if(collision.gameObject.CompareTag("Stick"))
        {
            cube3 = true;
        }
        
        if (cube1 && cube2 && cube3)
        {
            //Debug.Log("Enemy and Ground collision");
            svampar.spawnMushroom = true;
        }
    }
}
