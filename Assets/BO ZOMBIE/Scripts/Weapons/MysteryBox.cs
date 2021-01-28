using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    public int cost;
    public GameObject uiText;

    public List<Weapon> weaponList = new List<Weapon>();
    public List<Transform> spawnPoints = new List<Transform>();
    private int _counter;

    void Start()
    {
        int random = Random.Range(0, spawnPoints.Count);
        
        transform.position = spawnPoints[random].position;
        transform.rotation = spawnPoints[random].rotation;
    }

    public void Update()
    {
        if (_counter > 3)
        {
            int random = Random.Range(0, spawnPoints.Count);
            while (spawnPoints[random].position == transform.position)
            {
                random = Random.Range(0, spawnPoints.Count);
            }

            transform.position = spawnPoints[random].position;
            transform.rotation = spawnPoints[random].rotation;
            _counter = 0;
        }
    }


    public Weapon MysteryWeapon()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].Reset();
        }
        
        int randomInt = Random.Range(0, weaponList.Count);

        while (FindObjectOfType<PlayerShoot>().inventory.Contains(weaponList[randomInt]))
        {
            randomInt = Random.Range(0, weaponList.Count);
        }

        _counter++;
        return weaponList[randomInt];
    }
}
