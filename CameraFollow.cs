using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public float distY;
    public float distX;
    float moveY;
    float moveX;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (playerPos)
        {
            moveY = playerPos.position.y - transform.position.y;
            moveX = playerPos.position.x - transform.position.x;
        }
        else
        {
            moveY = 0;
            moveX = 0;
        }
        if(Mathf.Abs(moveY) > distY)
        {
            if(moveY > 0)
                transform.position += new Vector3(0, moveY - distY, 0); 
            else if(moveY < 0)
                transform.position += new Vector3(0, moveY + distY, 0);
        }
        if(Mathf.Abs(moveX) > distX)
        {
            if (moveX > 0)
                transform.position += new Vector3(moveX - distX, 0, 0);
            else if (moveX < 0)
                transform.position += new Vector3(moveX + distX, 0, 0);
        }

        
    }
}
