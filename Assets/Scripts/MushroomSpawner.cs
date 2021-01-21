using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public bool spawnMushroom;
    
    ObjectPooler objectPooler;
    private void Start()
    {
    objectPooler = ObjectPooler.Instance;
        spawnMushroom = false;
    }
     
    void FixedUpdate()
    {        
        if (spawnMushroom == true)
        {           
            objectPooler.spawnFromPool("Mushroom", transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Inga svampar");
        }     
    }
}

