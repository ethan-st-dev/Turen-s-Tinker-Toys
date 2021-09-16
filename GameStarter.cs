using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStarter : MonoBehaviour
{
    // Start is called before the first frame update
   // public Text txt;
    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("TTTInterior");
        GameManager.gameManager.enemiesKilled = 0;
        GameManager.gameManager.enemiesSpawned = 0;
        GameManager.gameManager.played1 = false;
        GameManager.gameManager.played2 = false;
        GameManager.gameManager.played3 = false;
        // txt.text = "High Score:" + GameManager.gameManager.highScore;
        GameManager.gameManager.playerHealth = GameManager.gameManager.playerHealthMax;
    }
}
