﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] public Vector2 moveDir;
    public float speed;
    private Rigidbody2D _rb;


    [Space] [Header("Rotation")] private Camera cam;
    public float angle;

    public float score;
    public TextMeshProUGUI txtScore;

    public bool _isNearBox;



    public Animator AnimatorWalking;
    public Animator AnimatorMB;

    public float timerConstruct = .8f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        moveDir = new Vector2(horizontal, vertical);



        if (horizontal != 0 || vertical != 0)
        {
            AnimatorWalking.SetBool("IsWalking", true);
        }
        else
        {
            AnimatorWalking.SetBool("IsWalking", false);
        }

        txtScore.text = $"Score : " + score.ToString("F0");

        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("e");
        }
        


        if (_isNearBox)
        {
            if (Input.GetButtonDown("Interact") && score > FindObjectOfType<MysteryBox>().cost)
            {
                AudioManager.audioManager.Play("MBOpen");
                AudioManager.audioManager.Play("MBDie");
                AnimatorMB.SetBool("MBOpened", true);
                score -= FindObjectOfType<MysteryBox>().cost;
                Debug.Log("Interaction");
                //GetComponent<PlayerShoot>().ReplaceWeapon(other.gameObject.GetComponent<MysteryBox>().MysteryWeapon());
                FindObjectOfType<MysteryBox>().Bonus();
            }
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
        PlayerRotation();
    }

    public void PlayerMove()
    {
        _rb.MovePosition(_rb.position + moveDir * speed * Time.fixedDeltaTime);
    }

    public void PlayerRotation()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.GetChild(0).position);

        Vector2 lookDir = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mystery Box") && !GetComponent<PlayerShoot>().bonus)
        {
            _isNearBox = true;
            other.gameObject.GetComponent<MysteryBox>().uiText.SetActive(true);
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mystery Box"))
        {
            _isNearBox = false;
            
            other.GetComponent<MysteryBox>().uiText.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Barricade") && Input.GetButton("Interact"))
        {
            speed = 0;
            if (other.GetComponent<Barricades>().life < 5)
            {
                timerConstruct += Time.deltaTime;
                if (timerConstruct >= .8f)
                {
                    AudioManager.audioManager.Play("BarricadeConstruct");
                    timerConstruct = 0;
                }
                
                    
                other.GetComponent<Barricades>().life += Time.deltaTime*1.7f;
                score += Time.deltaTime*2;
            }
        }

        if (other.CompareTag("Barricade") && (!Input.GetButton("Interact")|| other.GetComponent<Barricades>().life >= 5))
        {
            speed = 5;
        }
        
        
    }
}