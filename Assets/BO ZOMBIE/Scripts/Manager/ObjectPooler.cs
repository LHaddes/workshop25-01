﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

        #region Singleton

    public static ObjectPooler objectPooler;

    private void Awake()
    {
        objectPooler = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionnary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            return null;
        }

        GameObject objectToSpawn = poolDictionnary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.localPosition = position;
        objectToSpawn.transform.localRotation = rotation;
        poolDictionnary[tag].Enqueue(objectToSpawn);
        
        if (objectToSpawn.GetComponent<IPooledObject>() != null)
        {
            objectToSpawn.GetComponent<IPooledObject>().OnObjectSpawn();
        }
        
        return objectToSpawn;
    }
}