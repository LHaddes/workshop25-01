using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
