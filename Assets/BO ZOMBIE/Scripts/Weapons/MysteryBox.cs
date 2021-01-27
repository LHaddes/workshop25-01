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
        Debug.Log("enter function");
        for (int i = 0; i < weaponList.Count; i++)
        {
            weaponList[i].Reset();
        }
        
        int randomInt = Random.Range(0, weaponList.Count);

        while (FindObjectOfType<PlayerShoot>().inventory.Contains(weaponList[randomInt]))
        {
            randomInt = Random.Range(0, weaponList.Count);
        }
        return weaponList[randomInt];
    }
}
