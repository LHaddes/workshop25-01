using UnityEngine;

public class EnemisDetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == GetComponentInParent<EnemiBehaviour>().player)
        {
            GetComponentInParent<EnemiBehaviour>().goToPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (GetComponentInParent<EnemiBehaviour>() && other.gameObject == GetComponentInParent<EnemiBehaviour>().player)
        {
            GetComponentInParent<EnemiBehaviour>().goToPlayer = false;
        }
    }
}