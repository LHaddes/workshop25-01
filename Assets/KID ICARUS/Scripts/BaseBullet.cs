using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public int degats;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls") || other.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.GetComponent<PlayerLife>())
        {
            other.gameObject.GetComponent<PlayerLife>().Hurt(degats);
            gameObject.SetActive(false);
        }
    }
}
