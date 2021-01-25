using UnityEngine;

public class EnemiHitRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("je peux taper le joueur");
        GetComponentInParent<EnemiBehaviour>().playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("je ne peux plus taper le joueur ");
        GetComponentInParent<EnemiBehaviour>().playerInRange = false;
    }
}
