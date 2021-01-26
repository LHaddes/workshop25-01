using UnityEngine;

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
        ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);
        
        
        if (movementX > 0)
        {
            //TODO le player va à droite et regarde à droite
        }

        else if (movementX < 0)
        {
            //TODO le player va à gauche et regarde à droite
        }

        else if (movementY > 0)
        {
            
            //TODO le player va en haut et regarde en haut
        }

        else if (movementY < 0)
        {
            //TODO le player va en bas et regarde en haut
        }

        if (movementX == 0 && movementY == 0)
        {
            //TODO Tir base
        }
    }
}