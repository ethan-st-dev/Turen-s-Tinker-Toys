using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GerboShooting : MonoBehaviour
{
    public AIPath aiPath;
    Vector2 mousePos;

    public Rigidbody2D rb;
    public Camera cam;

    private float timeLeft = 0;
    private float shootDelay;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;

    public float bulletForce = 20f;
    float angle;
    bool shot;
    public Animator anim;
    

    // Update is called once per frame

    void Update()
    {
        //Checking if "Shot" is set to true
       // if (shot == true)
       // {
       //     Shoot();
        //    shot = false;
      //  }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        //Changing rotation when shooting
        if (Input.GetMouseButtonDown(1))
        {
            rb.rotation = angle;
            timeLeft = 0.5f;
            shootDelay = 0.1f;
            shot = true;
        }
        //Timer: If shooting
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft <= 0)
        {
            if (System.Math.Abs(aiPath.desiredVelocity.y) > 0 && System.Math.Abs(aiPath.desiredVelocity.x) > 0)
            {
                angle = Mathf.Atan2(aiPath.desiredVelocity.y, aiPath.desiredVelocity.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
            }
        }
        anim.SetFloat("Boost", aiPath.desiredVelocity.y);

        if (shot == true)
        {
            shootDelay -= Time.deltaTime;
            if (shootDelay <= 0)
            {
                Shoot();
                shot = false;
            }
            
        }

    }
    void Shoot()
    {
        AudioSource ShootN = Instantiate(shootSound, transform.position, Quaternion.identity);
        Destroy(ShootN, 1.5f);

        GameObject bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigD = bullet.GetComponent<Rigidbody2D>();
        rigD.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
