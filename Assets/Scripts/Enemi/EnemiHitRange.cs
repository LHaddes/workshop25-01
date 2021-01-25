using UnityEngine;

public class EnemiHitRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GetComponentInParent<EnemiBehaviour>().player)
        {
            GetComponentInParent<EnemiBehaviour>().playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy && other.gameObject == GetComponentInParent<EnemiBehaviour>().player)
        {
            GetComponentInParent<EnemiBehaviour>().playerInRange = false;
        }
    }
}