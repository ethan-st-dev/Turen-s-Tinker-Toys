using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioSource BallHum;
    public AudioSource explosionNoise;
    AudioSource HUM;

    public void Awake()
    {
       HUM = Instantiate(BallHum, transform.position, Quaternion.identity);
        
    }

    int damage = 1;
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
            GameObject Hiteffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(Hiteffect, 0.5f);

            AudioSource EXPBlip = Instantiate(explosionNoise, transform.position, Quaternion.identity);
            Destroy(EXPBlip, 1f);

            Destroy(gameObject);
            Destroy(HUM);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);

        AudioSource EXPBlip = Instantiate(explosionNoise, transform.position, Quaternion.identity);
        Destroy(EXPBlip, 1f);

        Destroy(gameObject);
        Destroy(HUM);
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.DamageEnemy(damage); 
        }
    }



}
