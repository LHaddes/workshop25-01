using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int maxLifePoints;

    public int currentLifePoints;

    public bool isInvulnerable;
    public float invincibilityBlink;
    private float timer;

    public Sprite[] lifebar;
    public Image imageLifebar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    public void Hurt(int damage)
    {
        if (!isInvulnerable)
        {
            AudioManager.audioManager.Play("PlayerHurt");
            currentLifePoints -= damage;
            imageLifebar.sprite = lifebar[currentLifePoints];
            isInvulnerable = true;
        }
    }

    public void Death()
    {
        GameplayManager.gameplayManager.GameOver();
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
