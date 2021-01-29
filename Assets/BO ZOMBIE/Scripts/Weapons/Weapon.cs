using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public bool isRiffle;
    public bool isBonus;   //Si l'arme tire en automatique ou non
    public bool fireRateBonus, infiniteAmmoBonus, allAmmoBonus, damageUpBonus;
    public int actualAmmo;    //Le nombre actuel de munition de notre chargeur
    public int magazineAmmo;    //Len ombre de munitions max d'un chargeur
    public int totalAmmo;    //Le nombre de munitions total qu'on transporte
    public float reloadTime;

    public float fireRate;
    public int damage;


    public int saveActualAmmo;
    public int saveTotalAmmo;
    public int saveDamage;
    public float saveFireRate;
    

    public string weaponSound;
    public Sprite weaponSprite;

    void OnEnable()
    {
        isBonus = false;
        saveActualAmmo = actualAmmo;
        saveTotalAmmo = totalAmmo;
        saveDamage = damage;
        saveFireRate = fireRate;
    }

    void OnDisable()
    {
        isBonus = false;
        actualAmmo = saveActualAmmo;
        totalAmmo = saveTotalAmmo;
        damage = saveDamage;
        fireRate = saveFireRate;
    }

    public void Reset()
    {
        actualAmmo = saveActualAmmo;
        totalAmmo = saveTotalAmmo;
    }
}
