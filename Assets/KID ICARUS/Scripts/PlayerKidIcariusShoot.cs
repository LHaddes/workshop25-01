using UnityEngine;

public class PlayerKidIcariusShoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = GetComponent<PlayerKidIcariusMovement>().xMove;
        float movementY = GetComponent<PlayerKidIcariusMovement>().yMove;
        Vector3 mousePosition = Input.mousePosition;
        float mousePositionX = mousePosition.x;
        float mousePositionY = mousePosition.y;
        float playerPositionX = transform.position.x;
        float playerPositionY = transform.position.y;
        
        if (movementX > 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à droite et regarde à droite
        }

        else if (movementX < 0 && mousePositionX > playerPositionX)
        {
            //TODO le player va à gauche et regarde à droite
        }
        else if (movementX > 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à droite et regarde à gauche
        }
        else if (movementX < 0 && mousePositionX < playerPositionX)
        {
            //TODO le player va à gauche et regarde à gauche
        }
        else if (movementY > 0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en haut et regarde en haut
        }
        else if (movementY > 0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en haut et regarde en bas
        }
        else if (movementY <0 && mousePositionY > playerPositionY)
        {
            //TODO le player va en bas et regarde en haut
        }
        else if (movementY <0 && mousePositionY < playerPositionY)
        {
            //TODO le player va en bas et regarde en bas
        }
    }
}