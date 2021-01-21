using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
    objectPooler = ObjectPooler.Instance;
    }

    //private void OnCollisionEnter(Collision collisionInfo)
    //{
        //if (collisionInfo.collider.CompareTag("Grabbable"))
        //{
            //objectPooler = ObjectPooler.Instance;
        //}
    //}
    void FixedUpdate()
    {
        objectPooler.spawnFromPool("Mushroom", transform.position, Quaternion.identity);
    }
}

