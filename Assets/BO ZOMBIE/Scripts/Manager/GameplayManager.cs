using TMPro;
using UnityEngine;


public class GameplayManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI nbEnemisText;
    public TextMeshProUGUI nbMoneyText;
    public TextMeshProUGUI timerText;

    public Transform[] posForMagicBoxes;

    public GameObject MagicBox;
    
    public int nbMoneyPlayer;
    public int nbWave;

    public float countdownBetweenTwoWaves;
    public float timer;
    
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
        timer += Time.deltaTime;
    }
    
    public void UpdateEnemis(int nbEnemis)
    {
        nbEnemisText.text = nbEnemis.ToString();
        timerText.text = timer.ToString("F0");
    }

    public void UpdateMoney(int nbMoney)
    {
        nbMoneyPlayer += nbMoney;
        nbMoneyText.text = nbMoneyPlayer.ToString();
    }

    public void SetMagicBox()
    {
        MagicBox.transform.position = posForMagicBoxes[Random.Range(0, posForMagicBoxes.Length)].position;
        MagicBox.SetActive(true);
    }
}
