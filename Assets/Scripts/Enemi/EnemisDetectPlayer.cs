using UnityEngine;

public class EnemisDetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("je vois le joueur");
        GetComponentInParent<EnemiBehaviour>().goToPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("je ne vois plus le joueur");
        GetComponentInParent<EnemiBehaviour>().goToPlayer = false;
    }
}
