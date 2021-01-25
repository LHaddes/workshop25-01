using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Weapon and Inventory")]
    public Weapon actualWeapon;
    public List<Weapon> inventory = new List<Weapon>(2);
    public int actualWeaponID;

    
    [Space]
    [Header("Shooting")]
    public float fireRate;
    private float _nextFire;
    public Transform firePoint;

    void Start()
    {
        actualWeaponID = 0;
        actualWeapon = inventory[actualWeaponID];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            fireRate = actualWeapon.fireRate;
            
            _nextFire = Time.time + fireRate;
            Shoot();
        }
        

        if (Input.mouseScrollDelta.y != 0)
        {
            SwitchWeapon((int)Input.mouseScrollDelta.y);
        }
    }

    public void SwitchWeapon(int mouseScroll)
    {
        if (mouseScroll < 0)
        {
            actualWeaponID--;
            if (actualWeaponID < 0)
            {
                actualWeaponID = 1;
            }
            else if(actualWeaponID > 1)
            {
                actualWeaponID = 0;
            }

            if (inventory[actualWeaponID] != null)
            {
                actualWeapon = inventory[actualWeaponID];
            }
            else
            {
                actualWeaponID++;    //RESET
            }
        }
        else if (mouseScroll > 0)
        {
            actualWeaponID++;
            if (actualWeaponID < 0)
            {
                actualWeaponID = 1;
            }
            else if(actualWeaponID > 1)
            {
                actualWeaponID = 0;
            }

            if (inventory[actualWeaponID] != null)
            {
                actualWeapon = inventory[actualWeaponID];
            }
            else
            {
                actualWeaponID--;    //RESET
            }
        }
    }

    public void Shoot()
    {
        if (Time.time >= fireRate)
        {
            Debug.Log("Shoot" + fireRate);
            //TODO Tir du player
            //GameObject obj = Instantiate(bulletPrefab, firePointTransform.position, firePointTransform.rotation);
        }
    }
}
