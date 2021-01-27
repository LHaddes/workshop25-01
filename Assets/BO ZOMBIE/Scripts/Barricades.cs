using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricades : MonoBehaviour
{
    public int life = 5;

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

        if (life == 0)
        {
            //GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    
}