using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public TextMeshProUGUI nbEnemisText;
    public TextMeshProUGUI nbMoneyText;

    public Transform[] posForMagicBoxes;
    
    public int nbMoneyPlayer;
    public int nbWave;

    public float countdownBetweenTwoWaves;
    
    #region Singleton

    public static GameplayManager gameplayManager;

    private void Awake()
    {
        gameplayManager = this;
    }

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateEnemis(int nbEnemis)
    {
        nbEnemisText.text = nbEnemis.ToString();
    }

    public void UpdateMoney(int nbMoney)
    {
        nbMoneyPlayer += nbMoney;
        nbMoneyText.text = nbMoneyPlayer.ToString();
    }
}
