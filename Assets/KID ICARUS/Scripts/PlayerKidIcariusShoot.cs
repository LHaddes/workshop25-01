﻿using UnityEngine;

public class PlayerKidIcariusShoot : MonoBehaviour
{
    public float movementX, movementY;
    public Transform spawnPoint;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementX = GetComponent<PlayerKidIcariusMovement>().xMove;
        movementY = GetComponent<PlayerKidIcariusMovement>().yMove;
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector3 mousePosition = GetComponent<PlayerKidIcariusMovement>().lookDirection;

        float mousePositionX = mousePosition.x;
        float mousePositionY = mousePosition.y;

        float playerPositionX = transform.position.x;
        float playerPositionY = transform.position.y;



        if (movementX > 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à droite et regarde à droite
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementX > 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à droite et regarde à gauche
            ObjectPooler.objectPooler.SpawnFromPool("BackBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementX < 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à gauche et regarde à gauche
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementX < 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à gauche et regarde à droite
            ObjectPooler.objectPooler.SpawnFromPool("BackBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementY > 0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en haut et regarde en haut
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementY > 0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en haut et regarde en bas
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementY < 0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en bas et regarde en bas
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
        else if (movementY < 0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en bas et regarde en haut
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }


        if (movementX == 0 && movementY == 0)
        {
            //TODO Tir base
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
    }
}