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
    public bool canSwitchWeapon = true;
    public Animator animator;

    [Space] [Header("Shooting")] 
    public bool canShoot = true;
    public float fireRate;
    private float _nextFire;
    public Transform firePoint;
    public ObjectPooler objectPooler;
    public TMP_Text ammoText;
    private float _reloadTime;
    private bool _isReloading;
    private bool _startCountdownBonus;
    public float durationBonus = 10f;
    private bool notUsingAmmo;
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
            
            animator.SetBool("IsFiring", true);
        }
        
        
        if (actualWeapon.isBonus)
        {
            durationBonus -= Time.deltaTime;

            if (actualWeapon.fireRateBonus)
            {
                fireRate /= 2;
                actualWeapon.fireRateBonus = false;
            }
            else if(actualWeapon.infiniteAmmoBonus)
            {
                notUsingAmmo = true;
                actualWeapon.infiniteAmmoBonus = false;
            }
            else if (actualWeapon.allAmmoBonus)
            {
                actualWeapon.Reset();
                actualWeapon.allAmmoBonus = false;
                durationBonus = 10f;
                actualWeapon.isBonus = false;
            }
            else if(actualWeapon.damageUpBonus)
            {
                actualWeapon.damage *= 2;
                actualWeapon.damageUpBonus = false;
            }
        }

        if (durationBonus <= 0)
        {
            actualWeapon.isBonus = false;
            fireRate *= 2;
            notUsingAmmo = false;
            actualWeapon.damage /= 2;
            durationBonus = 10f;
        }
        
        #region Scroll pour le changement d'armes

        if (Input.mouseScrollDelta.y != 0)    //Si on tourne la molette de la souris
        {
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
            
            //On vérifie qu'il y a plusieurs armes dans l'inventaire. Si oui, on lance le switch d'arme, sinon on ne le lance pas
            if (canSwitchWeapon)
            {
                SwitchWeapon((int)Input.mouseScrollDelta.y);
            }
            
        }

        #endregion



        #region Rechargement

        if (Input.GetButtonDown("Reload"))
        {
            if (actualWeapon.actualAmmo == actualWeapon.magazineAmmo || actualWeapon.totalAmmo <= 0)
            {
                return;    //Si on a déjà le max de munition dans notre chargeur ou qu'on n'a plus de munitions pour recharger, on ne fait rien
            }
            
            if (actualWeapon.actualAmmo <= actualWeapon.magazineAmmo && actualWeapon.totalAmmo > 0)
            {
                _isReloading = true;
            }
        }

        if (_isReloading)
        {
            AudioManager.audioManager.Play("GunReloading");

            _reloadTime += Time.deltaTime;
            canSwitchWeapon = false;
            canShoot = false;    //On empêche le tir pendant le rechargement
                
            if (_reloadTime >= actualWeapon.reloadTime)
            {
                //On calcule s'il y a assez de munitions pour recharger l'arme entièrement. Si oui, on dit que les munitions actuelles valent les munitions maximum d'un chargeur
                if (actualWeapon.totalAmmo >= (actualWeapon.magazineAmmo - actualWeapon.actualAmmo))
                {
                    actualWeapon.totalAmmo -= (actualWeapon.magazineAmmo - actualWeapon.actualAmmo);
                    actualWeapon.actualAmmo = actualWeapon.magazineAmmo;
                }
                //Sinon, on calcule combien de munitions on ajoute et on passe le nombre de munitions restant à 0
                else
                {
                    actualWeapon.actualAmmo += actualWeapon.totalAmmo;
                    actualWeapon.totalAmmo = 0;
                }
                
                
                canShoot = true;
                canSwitchWeapon = true;

                ammoText.text = $"{actualWeapon.actualAmmo} / {actualWeapon.totalAmmo}";    //On met à jour l'ui

                AudioManager.audioManager.Play("ReloadCompleted");

                _reloadTime = 0;
                _isReloading = false;
            }
        }

        #endregion
        
        ammoText.text = $"{actualWeapon.actualAmmo} / {actualWeapon.totalAmmo}";

        
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
            GameObject obj = objectPooler.SpawnFromPool("PlayerBullet", firePoint.position, firePoint.rotation);
            obj.GetComponent<PlayerBullet>().degats = actualWeapon.damage;
            AudioManager.audioManager.Play(actualWeapon.weaponSound);
            actualWeapon.actualAmmo--;
        }
        else if (Time.time >= fireRate && actualWeapon.actualAmmo <= 0 && actualWeapon.totalAmmo > 0)
        {
            _isReloading = true;
        }
    }


    public void ReplaceWeapon(Weapon newWeapon)
    {
        inventory[actualWeaponID] = newWeapon;
        actualWeapon = newWeapon;
    }
}
