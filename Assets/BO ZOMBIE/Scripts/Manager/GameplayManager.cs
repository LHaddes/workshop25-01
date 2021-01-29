using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class GameplayManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI nbEnemisText;
   
    

    public GameObject player;
    
    
    [Header("Wave and Gameplay Management")]
    public int nbWave = -1;
    public float countdownBetweenTwoWaves;
    public int actualNbEnemies, nbEnemies;
    public List<Transform> spawnZombies = new List<Transform>();
    
    [Header("Game Over")]
    public GameObject gameOverMenu;
    public TMP_Text waveText;


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
        Time.timeScale = 1f;
        player = GameObject.FindWithTag("Player");
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualNbEnemies <= 0)
        {
            countdownBetweenTwoWaves -= Time.deltaTime;
            nbEnemisText.text = "Wave finished !";
            
            if (countdownBetweenTwoWaves <= 0)
            {
                nbEnemies += Random.Range(4, 8);
                StartWave();
                countdownBetweenTwoWaves = 10f;
            }
        }
    }
    
    public void UpdateEnemis()
    {
        nbEnemisText.text = $"Remaining : {actualNbEnemies}\n" +
                            $"Wave : {nbWave}";
    }

    public void StartWave()
    {
        Debug.Log("Start Wave");
        nbWave++;
        actualNbEnemies = nbEnemies;

        for (int i = 0; i < actualNbEnemies; i++)
        {
            int random = Mathf.FloorToInt(Random.Range(0, spawnZombies.Count));
            ObjectPooler.objectPooler.SpawnFromPool("Enemy", spawnZombies[random].position, spawnZombies[random].rotation);
        }
        
        UpdateEnemis();
    }

    
    //GAME OVER
    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        waveText.text = $"You survived {nbWave} waves.";
        Time.timeScale = 0f;
    }
}
