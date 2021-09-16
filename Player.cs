using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public AudioSource Tink;
    public GameObject wound;
    public GameObject playerDeath;
    [System.Serializable]
    public class PlayerStats
    {
        public int health = 100;
    }
    public PlayerStats playerStats = new PlayerStats();
    public void Update()
    { 
        GameManager.gameManager.playerHealth = playerStats.health;
        GameManager.gameManager.hud.ResetHud();
    }
    public void DamagePlayer(int damage)
    {
        AudioSource Woundsound = Instantiate(Tink, transform.position, Quaternion.identity);
        Destroy(Woundsound, 0.5f);

        GameObject Wound = Instantiate(wound, transform.position, Quaternion.identity);
        Destroy(Wound, 0.2f);
        playerStats.health -= damage;
        if (playerStats.health <= 0)
        {
            Destroy(this.gameObject);
            Explode();  
        }
       
    }
    public void Explode()
    {
        GameObject playerdeath = Instantiate(playerDeath, transform.position, Quaternion.identity);
        Destroy(playerdeath, 0.3f);
        GameManager.gameManager.GameOver();
    }
    
}
