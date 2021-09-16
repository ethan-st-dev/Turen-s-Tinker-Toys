using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class OnClick : MonoBehaviour
{
    public Transform prefab;
    Transform target;
    bool isTarget = false;
    Seeker seeker;
    public Path path;
    private int currentWaypoint = 0;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("A path was calculated. Did it fail with an error? " + p.error);

        p.Claim(this);
        if (!p.error)
        {
            if (path != null) path.Release(this);
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
        else
        {
            p.Release(this);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Vector3 endpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endpoint.z = 0;
            if (isTarget == false)
            {
                target = Instantiate(prefab, endpoint, Quaternion.identity);
                seeker.StartPath(transform.position, endpoint, OnPathComplete);
                isTarget = true;
            }
            else if(isTarget)
            {
                if(target != null)
                    Destroy(target.gameObject);
                seeker.StartPath(transform.position, endpoint, OnPathComplete);
                target = Instantiate(prefab, endpoint, Quaternion.identity);
            }
        }
        if (target != null && Vector2.Distance(transform.position, target.position) <= .2)
        {
            Destroy(target.gameObject);
            isTarget = false;
        }
    }

   
}