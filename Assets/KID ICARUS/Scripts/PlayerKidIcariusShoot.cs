using UnityEngine;

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
        Vector3 mousePosition = Input.mousePosition;

        float mousePositionX = mousePosition.x;
        float mousePositionY = mousePosition.y;

        float playerPositionX = transform.position.x;
        float playerPositionY = transform.position.y;


        ObjectPooler.objectPooler.SpawnFromPool("BaseBullet", spawnPoint.position, spawnPoint.rotation);

        if (movementX > 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à droite et regarde à droite
        }
        else if (movementX > 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à droite et regarde à gauche
        }
        else if (movementX < 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à gauche et regarde à gauche
        }
        else if (movementX < 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à gauche et regarde à droite
        }
        else if (movementY > 0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en haut et regarde en haut
        }
        else if (movementY > 0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en haut et regarde en bas
        }
        else if (movementY < 0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en bas et regarde en bas
        }
        else if (movementY < 0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en bas et regarde en haut
        }


        if (movementX == 0 && movementY == 0)
        {
            //TODO Tir base
        }
    }
}