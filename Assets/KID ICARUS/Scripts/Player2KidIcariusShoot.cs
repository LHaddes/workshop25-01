﻿using UnityEngine;

public class Player2KidIcariusShoot : MonoBehaviour
{
    public float movementX, movementY;
    public Transform spawnPoint;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementX = GetComponent<Player2KidIcarius>().xMove;
        movementY = GetComponent<Player2KidIcarius>().yMove;
            
        if (Input.GetButtonDown("P2Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector3 mousePosition = GetComponent<Player2KidIcarius>().lookDirection;

        float mousePositionX = mousePosition.x;
        float mousePositionY = mousePosition.y;

        float playerPositionX = transform.position.x;
        float playerPositionY = transform.position.y;
  
        
        
        if (movementX > 0 && mousePositionX > playerPositionX)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va à droite et regarde à droite
        }
        else if (movementX > 0 && mousePositionX < playerPositionX)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BackBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va à droite et regarde à gauche
        }
        else if (movementX < 0 && mousePositionX < playerPositionX)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va à gauche et regarde à gauche
        }
        else if (movementX < 0 && mousePositionX > playerPositionX)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BackBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va à gauche et regarde à droite
        }
        else if (movementY > 0 && mousePositionY > playerPositionY)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va en haut et regarde en haut
        }
        else if (movementY > 0 && mousePositionY < playerPositionY)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va en haut et regarde en bas
        }
        else if (movementY < 0 && mousePositionY < playerPositionY)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va en bas et regarde en bas
        }
        else if (movementY < 0 && mousePositionY > playerPositionY)
        {
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
            //TODO le player va en bas et regarde en haut
        }


        if (movementX == 0 && movementY == 0)
        {
            //TODO Tir base
            ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        }
    }
}