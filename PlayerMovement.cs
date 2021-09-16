using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startpoint;

    private Vector3 endpoint;

    private float journeyLength;

    private float startTime;
    public float speed;

    //private float vel;

    public float distProximity;

    public bool isLerping = false;

    float speedTemp;

    private Rigidbody2D rigid;
   // public Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
       
        speedTemp = speed;
        rigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //vel = speed * Time.deltaTime;
            startTime = Time.time;
            startpoint = transform.position;
            endpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endpoint.z = 0;
            journeyLength = Vector3.Distance(startpoint, endpoint);
            isLerping = true;
        }
        if (isLerping == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            var moveTo = Vector3.Lerp(transform.position, endpoint, fractionOfJourney);
            rigid.MovePosition(moveTo);
            if (fractionOfJourney >= 1.0f)
            {
                isLerping = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("HIT");
        if(collision.collider.CompareTag("Obstacles"))
        {
            endpoint = transform.position;
           
        }
    }

}
