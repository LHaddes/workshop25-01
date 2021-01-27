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
    

    [Space]
    [Header("Rotation")]
    private Camera cam;
    public float angle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
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
        
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
