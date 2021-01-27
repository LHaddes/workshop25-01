using System;
using System.Collections;
using System.Collections.Generic;
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

    public int score;


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
        if (other.gameObject.CompareTag("Mystery Box"))
        {
            Debug.Log("boite");
            //TODO Afficher UI Mystery Box
            other.gameObject.GetComponent<MysteryBox>().uiText.SetActive(true);

            if (Input.GetButtonDown("Interact") /*&& score > other.gameObject.GetComponent<MysteryBox>().cost*/)
            {
                Debug.Log("Interaction");
                GetComponent<PlayerShoot>().ReplaceWeapon(other.gameObject.GetComponent<MysteryBox>().MysteryWeapon());
            }
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mystery Box"))
        {
            Debug.Log("sortie boite");
            other.GetComponent<MysteryBox>().uiText.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Barricade") && Input.GetKey(KeyCode.E))
        {
            speed = 0;
            if (other.GetComponent<Barricades>().life < 5)
            {
                other.GetComponent<Barricades>().life += Time.deltaTime*1.7f;
                score += 5;
            }
        }

        if (other.CompareTag("Barricade") && (Input.GetKeyUp(KeyCode.E)|| other.GetComponent<Barricades>().life >= 5))
        {
            speed = 5;
        }
        
        if (other.gameObject.CompareTag("Mystery Box") && Input.GetButtonDown("Interact") /*&& score > other.gameObject.GetComponent<MysteryBox>().cost*/)
        {
            
            
                Debug.Log("Interaction");
                GetComponent<PlayerShoot>().ReplaceWeapon(other.gameObject.GetComponent<MysteryBox>().MysteryWeapon());
            
        }
    }
}