using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2KidIcarius : MonoBehaviour
{
    private bool _canJump = false;

    public float forceJump;
    public float speed;
    public int jumpCount;
    [HideInInspector]
    public float xMove;
    public float yMove;

    private float _angle;
    
    public GameObject directionShoot;

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal2");
        yMove = Input.GetAxisRaw("Vertical2");
        GunRotation();
        if (_canJump && Input.GetKeyDown(KeyCode.Keypad0))
        {
            Jump(Vector2.up);
        }

        transform.position += new Vector3(xMove, 0, 0).normalized * speed * Time.deltaTime;
    }

    void Jump(Vector2 dir)
    {
        jumpCount++;
        
        _rb.velocity = new Vector2(_rb.velocity.x, 0);
        _rb.velocity += dir * forceJump;
        
        if (jumpCount >= 2)
        {
            _canJump = false;
            jumpCount = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            _canJump = true;
        }
    }

    public void GunRotation()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.GetChild(0).position);

        Vector2 lookDir = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        _angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        directionShoot.transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
