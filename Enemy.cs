using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource dieBlip;
    public GameObject BloodSplatter;

    public AudioClip die1;
    public AudioClip die2;
    public AudioClip die3;

    int numPlay;
    
    [System.Serializable]
    public class EnemyStats
    {
        public int health = 100;
    }

    public EnemyStats enemyStats = new EnemyStats();
    public GoblinSpawner spawner;

    public void FixedUpdate()
    {
        numPlay = Random.Range(1, 4);
    }
    public void DamageEnemy(int damage)
    {
        enemyStats.health -= damage;

        if (enemyStats.health <= 0)
        {
            GameObject effect = Instantiate(BloodSplatter, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            AudioSource DieDie = Instantiate(dieBlip, transform.position, Quaternion.identity);
            if(numPlay == 1)
            {
                DieDie.clip = die1;
                DieDie.Play();
            }
            else if(numPlay == 2)
            {
                DieDie.clip = die2;
                DieDie.Play();
            }
            else if(numPlay == 3)
            {
                DieDie.clip = die3;
                DieDie.Play();
            }
            Destroy(DieDie, 1.5f);

            if (spawner.numOfEnemies > 0)
            {
                GameManager.gameManager.enemiesKilled++;
                spawner.numOfEnemies -= 1;

            }
            Destroy(this.gameObject);
        }
    }
}
