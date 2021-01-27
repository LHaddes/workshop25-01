using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int maxLifePoints;

    public int currentLifePoints;

    public bool isInvulnerable;
    public float invincibilityBlink;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    public void Hurt(int damage)
    {
        if (!isInvulnerable)
        {
            currentLifePoints -= damage;
            isInvulnerable = true;
        }
    }

    public void Death()
    {
        //TODO GAME OVER
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvulnerable)
        {
            timer += Time.deltaTime;

            if (timer >= invincibilityBlink)
            {
                isInvulnerable = false;
                timer = 0f;
            }
        }
        
        if (currentLifePoints <= 0)
        {
            Death();
        }
    }
}
