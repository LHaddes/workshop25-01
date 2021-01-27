using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MysteryBox : MonoBehaviour
{
    public int cost;
    public GameObject uiText;

    public List<Weapon> weaponList = new List<Weapon>();


    public Weapon MysteryWeapon()
    {
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].Reset();
        }
        
        int randomInt = Random.Range(0, weaponList.Count);

        if (FindObjectOfType<PlayerShoot>().inventory.Contains(weaponList[randomInt]))
        {
            MysteryWeapon();
        }
        

        return weaponList[randomInt];
    }
}
