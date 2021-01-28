using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameplayManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI nbEnemisText;
    public TextMeshProUGUI nbMoneyText;
    public TextMeshProUGUI timerText;

    /*public Transform[] posForMagicBoxes;

    public GameObject MagicBox;*/
    
    public int nbMoneyPlayer;
    

    
    public float timer;

    public GameObject player;
    
    [Header("Wave and Gameplay Management")]
    public int nbWave;
    public int palierWave;
    public float countdownBetweenTwoWaves;
    public int nbEnemies;
    public List<Transform> spawnZombies = new List<Transform>();
    
    
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
        player = GameObject.FindWithTag("Player");

        nbWave++;
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    
    public void UpdateEnemis(int nbEnemis)
    {
        nbEnemisText.text = nbEnemis.ToString();
        timerText.text = timer.ToString("F0");
    }

    public void UpdateMoney(float nbMoney)
    {
        player.GetComponent<PlayerMovement>().score += nbMoney;
        nbMoneyText.text = Mathf.FloorToInt(player.GetComponent<PlayerMovement>().score).ToString();
    }

    /*
    public void SetMagicBox()
    {
        MagicBox.transform.position = posForMagicBoxes[Random.Range(0, posForMagicBoxes.Length)].position;
        MagicBox.SetActive(true);
    }*/

    public void StartWave()
    {
        nbEnemies = 5 * palierWave + 2 * nbWave;

        for (int i = 0; i < nbEnemies; i++)
        {
            //ObjectPooler.objectPooler.SpawnFromPool("Enemy", )
        }
        //TODO Spawn Zombies(5 * palier + 2 * nbWave)
    }
}


public class Wave
{
    public int nbZombies;
}
