using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricades : MonoBehaviour
{
    public float life = 5;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 0)
        {
            life = 0;
        }

        if (life >= 5)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (life <= 5 && life >= 2.5f)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else if (life <= 2.5f && life >= 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (life <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }
}