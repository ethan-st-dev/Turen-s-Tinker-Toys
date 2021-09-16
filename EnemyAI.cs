using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    Seeker seeker;
    public Path path;
   // public AIPath ai;
    Vector3 startPoint;
    public float rangeNotice;
    public float rangeAttack;
    private int currentWaypoint = 0;
    public float timeAttack;
    Player player;
    Vector3 endpoint;
    public int damage;
    public bool attacking = false;
    public bool seeking;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        startPoint = transform.position;
        StartCoroutine(UpdatePath());
        player = FindObjectOfType<Player>();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);
        p.Claim(this);
        if (!p.error)
        {
            if (path != null) path.Release(this);
            path = p;
            currentWaypoint = 0;
        }
        else
        {
            p.Release(this);
        }
    }

    //Moves the Enemy towards the player
    IEnumerator UpdatePath()
    {
        yield return new WaitForSeconds(.5f);
        if (player == null)
        {
            yield return false;
        }
        if (player)
            endpoint = player.transform.position;
        //If distance between player and enemy is greater than it's Notice Range but less thaan its Attack Range, move towards the player
        if (seeking && /*Vector2.Distance(player.transform.position, transform.position) <= rangeNotice &&*/ Vector2.Distance(player.transform.position, transform.position) > rangeAttack)
        {
            attacking = false;
            endpoint.z = 0;
            seeker.StartPath(transform.position, endpoint, OnPathComplete);
            yield return null;
            StartCoroutine(UpdatePath());
        }
        else if (!seeking && Vector2.Distance(player.transform.position, transform.position) <= rangeNotice && Vector2.Distance(player.transform.position, transform.position) > rangeAttack)
        {
            attacking = false;
            endpoint.z = 0;
            seeker.StartPath(transform.position, endpoint, OnPathComplete);
            yield return null;
            StartCoroutine(UpdatePath());
        }
        //else if distance is less or equal to its Attack Range, attack the player
        else if(Vector2.Distance(player.transform.position, transform.position) <= rangeAttack)
        {
            endpoint.z = 0;
            seeker.StartPath(transform.position, transform.position, OnPathComplete);
            yield return null;
            StartCoroutine(Attack());
            
        }

        //if its out of range, return to its original patrol point
        else
        {
            attacking = false;
            seeker.StartPath(transform.position, startPoint, OnPathComplete);
            yield return null;
            StartCoroutine(UpdatePath());
        }
    }

    //attacks the player
    IEnumerator Attack()
    {
        //Fix this to make wsure it doesnt wait first time it attacks.
        attacking = true;
        yield return new WaitForSeconds(timeAttack);
        if (player && Vector2.Distance(player.transform.position, transform.position) <= rangeAttack)
        {
            player.DamagePlayer(damage);
            StartCoroutine(Attack());
        }
        else
        {
            StartCoroutine(UpdatePath());
        }
    }
}
