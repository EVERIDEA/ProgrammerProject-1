using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingView : MonoBehaviour, IInitGame {

    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    [SerializeField]
    Pool[] dataPool;

    public void InitGame()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in dataPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag (" + tag + ") doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        PoolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
