using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
  
    public static bool isGameStarted;
    public GameObject startingText;
    public GameObject turulecaExplorer;
    public static int numberOfCoins;
    public Text coinsText;
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
        coinsText.text = "Coins: " + numberOfCoins;
        if(Input.GetKeyDown(KeyCode.Space)){
            isGameStarted = true;
            Destroy (startingText);
            Destroy (turulecaExplorer);
        }
    }
}
