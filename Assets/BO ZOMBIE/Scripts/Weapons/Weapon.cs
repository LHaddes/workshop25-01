using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public bool isAuto;   //Si l'arme tire en automatique ou non
    public bool isBonus ;
    public int actualAmmo;    //Le nombre actuel de munition de notre chargeur
    public int magazineAmmo;    //Len ombre de munitions max d'un chargeur
    public int totalAmmo;    //Le nombre de munitions total qu'on transporte
    public float reloadTime;

    public float fireRate;
    public int damage;


    private int saveActualAmmo;
    private int saveTotalAmmo;

    void OnEnable()
    {
        saveActualAmmo = actualAmmo;
        saveTotalAmmo = totalAmmo;
    }

    void OnDisable()
    {
        actualAmmo = saveActualAmmo;
        totalAmmo = saveTotalAmmo;
    }

    public void Reset()
    {
        actualAmmo = saveActualAmmo;
        totalAmmo = saveTotalAmmo;
    }
}
