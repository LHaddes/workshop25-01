using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABullets : MonoBehaviour
{
    public List<GameObject> bulletType = new List<GameObject>();
    public int id;
    public GameObject parent;

    [Header("Parameters")]
    [Header("Front Bullet & Back Bullet")]
    public float baseSpeed;

    [Header("Up Bullet")] 
    public float autoSpeed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        id = bulletType.IndexOf(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.name =="Player")
            transform.LookAt(GameObject.FindWithTag("Player2").transform);
        else 
        { 
            transform.LookAt(GameObject.FindWithTag("Player").transform);
        }
        
        
        transform.Translate(Vector3.up * autoSpeed * Time.deltaTime);
    }
}
