using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public  List<Transform> spawnPoint = new List<Transform>();
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int random = Mathf.FloorToInt(Random.Range(0, spawnPoint.Count));
            ObjectPooler.objectPooler.SpawnFromPool("Enemy", spawnPoint[random].position, spawnPoint[random].rotation);
            timer = 2.5f;
        }
    }
}
