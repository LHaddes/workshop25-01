using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKidIcariusMovement : MonoBehaviour
{
    private bool _canJump = false;

    public float forceJump;
    public float speed;
    public float angle;

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
        float xMove = Input.GetAxisRaw("Horizontal");
        GunRotation();
        if (_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        transform.position += new Vector3(xMove, 0, 0).normalized * speed * Time.deltaTime;
    }

    void Jump()
    {
        _rb.AddForce(new Vector2(0, forceJump));
        _canJump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            _canJump = true;
        }
    }

    public void GunRotation()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.GetChild(0).position);

        Vector2 lookDir = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        directionShoot.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}