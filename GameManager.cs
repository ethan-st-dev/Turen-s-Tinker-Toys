using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int playerHealth;
    public int playerHealthMax;

    public static GameManager gameManager;
    public float enemiesSpawned = 0;
    public float enemiesKilled = 0;
    public float maxEnemiesLevel1;
    public float maxEnemiesLevel2;
    public HUDManager hud;

    public AudioSource voiceClips;
    AudioSource audio;

    public AudioClip voice1;
    public AudioClip voice2;
    public AudioClip voice3;

    public bool played1;
    public bool played2;
    public bool played3;

    public string activeScene;

    // Start is called before the first frame update
    private void Awake()
    {
        //AudioSource audio = Instantiate(voiceClips, transform.position, Quaternion.identity);
        hud = FindObjectOfType<HUDManager>();
        playerHealthMax = playerHealth;
        if (gameManager == null)
            gameManager = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void FixedUpdate()
    {
        activeScene = SceneManager.GetActiveScene().name;
        if (audio == null)
            audio = Instantiate(voiceClips, transform.position, Quaternion.identity); 
        if (hud == null)
        {
            hud = FindObjectOfType<HUDManager>();
        }
        if (enemiesKilled == maxEnemiesLevel1 && activeScene == "TTTExterior+Town")
        {
            ResetGame();
            SceneManager.LoadScene("TTTExterior+Town 2");
        }
        else if(enemiesKilled == maxEnemiesLevel2 && activeScene == "TTTExterior+Town 2")
        {
            ResetGame();
            SceneManager.LoadScene("VictoryScreen");
        }
        if (!played1 && !audio.isPlaying && enemiesKilled >= 25)
        {
            audio.clip = voice1;
            audio.PlayDelayed(.5f);
            played1 = true;
        }
        if(!played2 && !audio.isPlaying && enemiesKilled >= 50)
        {
            audio.clip = voice2;
            audio.PlayDelayed(.5f);
            played2 = true;
        }
        if(!played3 && !audio.isPlaying && enemiesKilled >= 75)
        {
            audio.clip = voice3;
            audio.PlayDelayed(.5f);
            played3 = true;
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void ResetGame()
    {
        enemiesKilled = 0;
        enemiesSpawned = 0;
        played1 = false;
        played2 = false;
        played3 = false;
    }
    // Update is called once per frame
}
