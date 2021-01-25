using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class Weapon : ScriptableObject
{
    public bool isAuto;
    public float magazineAmmo;
    public float maxAmmo;

    public float fireRate;
    public int damage;
}
