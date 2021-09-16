using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
  
    public Text score;
    public Text health;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetHud();
    }

    public void ResetHud()
    {
        score.text = "Score: " + GameManager.gameManager.enemiesKilled;
        health.text = "Health: " + GameManager.gameManager.playerHealth;
    }
    
}
