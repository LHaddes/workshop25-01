using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemiBehaviour : MonoBehaviour
{
    public bool playerInRange = false;
    public bool goToPlayer = false;

    public float hitRate = 1f;
    public float speed = 2;

    public GameObject player;

    public int life;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");


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
                //TODO appliquer les dégâts au player
                //player.GetComponent<PlayerLife>().Hurt(1);
                Debug.Log("je touche le joueur");
                hitRate = 1f;
            }
        }

        if (goToPlayer)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (life <= 0)
        {
            player.GetComponent<PlayerMovement>().score += 15;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Barricade"))
        {
            if (other.GetComponent<Barricades>().life == 0)
            {
                speed = 2;
            }
            else
            {
                speed = 0;
                other.GetComponent<Barricades>().life -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}