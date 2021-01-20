using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectPooler2 : MonoBehaviour
{
    [System.Serializable]
    public class Pool2
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    #region Singleton
    public static ObjectPooler2 Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public List<Pool2> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary2;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary2 = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool2 pool in pools)
        {
            Queue<GameObject> objectPool2 = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj2 =Instantiate(pool.prefab);
                obj2.SetActive(false);
                objectPool2.Enqueue(obj2);
            }

            poolDictionary2.Add(pool.tag, objectPool2);
        }
    }

    public GameObject SpawnFromPool2(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary2.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " Doesnt exist");
            return null;
        }
        
        GameObject objectToSpawn2 = poolDictionary2[tag].Dequeue();
        objectToSpawn2.SetActive(true);
        objectToSpawn2.transform.position = position;
        objectToSpawn2.transform.rotation = rotation;

        poolDictionary2[tag].Enqueue(objectToSpawn2);

        return objectToSpawn2;
    }

}
