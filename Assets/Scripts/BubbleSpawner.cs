using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    ObjectPooler2 objectPooler2;
    private void Start()
    {
        objectPooler2 = ObjectPooler2.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectPooler2.SpawnFromPool2("Bubble", transform.position, Quaternion.identity);
    }
}
