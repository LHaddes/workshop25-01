using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiBehaviour : MonoBehaviour
{
    public bool playerInRange = false;
    public bool goToPlayer = false;

    public float hitRate = 1f;

    public GameObject player;

    public int life;


    private void Start()
    {
        playerInRange = false;
        goToPlayer = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            hitRate -= Time.deltaTime;
            if (hitRate <= 0)
            {
                //player.GetComponent<PlayerLife>().Hurt(1);
                Debug.Log("je touche le joueur");
                hitRate = 1f;
            }
        }

        if (goToPlayer)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (life < 0)
        {
            gameObject.SetActive(false);
        }
    }
}