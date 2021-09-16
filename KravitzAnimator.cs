using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KravitzAnimator : MonoBehaviour
{
    public AIPath ai;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(ai.desiredVelocity.y) > Mathf.Abs(ai.desiredVelocity.x))
        {
            anim.SetBool("Walking", true);
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", ai.desiredVelocity.y);
        }
        else if (Mathf.Abs(ai.desiredVelocity.y) < Mathf.Abs(ai.desiredVelocity.x))
        {
            anim.SetBool("Walking", true);
            anim.SetFloat("Vertical", 0);
            anim.SetFloat("Horizontal", ai.desiredVelocity.x);
        }
        else if (Mathf.Abs(ai.velocity.y) == 0 && Mathf.Abs(ai.velocity.x) == 0)
        {
            anim.SetBool("Walking", false);
        }

    }
}
