using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Weapon and Inventory")]
    public Weapon actualWeapon;
    public List<Weapon> inventory = new List<Weapon>(2);
    public int actualWeaponID;
    public bool canSwitchWeapon;


    [Space] [Header("Shooting")] 
    public bool canShoot = true;
    public float fireRate;
    private float _nextFire;
    public Transform firePoint;
    public ObjectPooler objectPooler;
    public TMP_Text ammoText;
    private float _reloadTime;

    void Start()
    {
        objectPooler = ObjectPooler.objectPooler;
        
        actualWeaponID = 0;
        actualWeapon = inventory[actualWeaponID];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextFire && canShoot)
        {
            fireRate = actualWeapon.fireRate;
            
            _nextFire = Time.time + fireRate;
            Shoot();
        }


        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == null)
            {
                canSwitchWeapon = false;
            }
            else
            {
                canSwitchWeapon = true;
            }
        }

        if (Input.mouseScrollDelta.y != 0 && canSwitchWeapon)
        {
            SwitchWeapon((int)Input.mouseScrollDelta.y);
        }
        

        ammoText.text = $"{actualWeapon.actualAmmo} / {actualWeapon.totalAmmo}";

        if (Input.GetButtonDown("Reload"))
        {
            if (actualWeapon.actualAmmo == actualWeapon.magazineAmmo)
            {
                return;
            }
            
            if (actualWeapon.actualAmmo <= actualWeapon.magazineAmmo)
            {
                _reloadTime += Time.deltaTime;
                canSwitchWeapon = false;
                canShoot = false;
                
                if (_reloadTime >= actualWeapon.reloadTime)
                {
                    actualWeapon.totalAmmo -= (actualWeapon.magazineAmmo - actualWeapon.actualAmmo);
                    actualWeapon.actualAmmo = actualWeapon.magazineAmmo;
                }
            }
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
        if (Time.time >= fireRate && actualWeapon.actualAmmo > 0)
        {
            Debug.Log("Shoot" + fireRate);
            //TODO Tir du player
            GameObject obj = objectPooler.SpawnFromPool("PlayerBullet", firePoint.position, firePoint.rotation);

            actualWeapon.actualAmmo--;
        }
    }
}
