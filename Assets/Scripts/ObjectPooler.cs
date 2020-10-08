using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public string id;
        public int numberToGenerate;
    }
    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolObjects = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        foreach(Pool pool in pools)
        {
            for(int i = 0; i < pool.numberToGenerate; i++)
            {
                if(!poolObjects.ContainsKey(pool.id))
                {
                    poolObjects.Add(pool.id, new Queue<GameObject>());
                }
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);

                poolObjects[pool.id].Enqueue(obj);
            }
        }
    }

    public GameObject SpawnObject(string id, Vector2 position, Quaternion rotation)
    {
        if (poolObjects.ContainsKey(id))
        {
            GameObject obj = poolObjects[id].Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);

            poolObjects[id].Enqueue(obj);
            return obj;
        }
        else
        {
            Debug.Log("poolObjects dictionary does not contain key: " + id);
            throw new ArgumentNullException();
        }
    }
}
