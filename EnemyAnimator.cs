using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAnimator : MonoBehaviour
{
    public AIPath ai;
    Animator anim;
    //public OnClick player;
    public OnClickGerbo player;
    EnemyAI enemy;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponentInParent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(ai.velocity.y) > Mathf.Abs(ai.velocity.x) && (Vector2.Distance(player.transform.position, enemy.transform.position) > enemy.rangeAttack))
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("Walking", true);
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", ai.velocity.y);
        }
        else if (Mathf.Abs(ai.velocity.y) < Mathf.Abs(ai.velocity.x) && (Vector2.Distance(player.transform.position, enemy.transform.position) > enemy.rangeAttack))
        {
            anim.SetBool("Attacking", false);
            anim.SetBool("Walking", true);
            anim.SetFloat("Vertical", 0);
            anim.SetFloat("Horizontal", ai.velocity.x);
        }
        else if (Mathf.Abs(ai.velocity.y) == 0 && Mathf.Abs(ai.velocity.x) == 0 && !enemy.attacking)
        {
            anim.SetBool("Walking", false);
        }
        else if (enemy.attacking)
        {
            anim.SetFloat("Vertical", 0);
            anim.SetFloat("Horizontal", 0);
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", true);

            /*******Fix This, make it turn while in range, and face toawrds the general direction of player while stabbing*******/

            //float distX = player.transform.position.x - transform.position.x;
            //float distY = player.transform.position.y - transform.position.y;

            //if (Mathf.Abs(distX) > Mathf.Abs(distY))
            //{
            //    anim.SetFloat("Vertical", 0);
            //    anim.SetFloat("Horizontal", 0);
            //    anim.SetFloat("FollowVert", 0);
            //    anim.SetFloat("FollowHoriz", distX);
              
            //}

            //if (Mathf.Abs(distX) < Mathf.Abs(distY))
            //{
            //    anim.SetFloat("Vertical", 0);
            //    anim.SetFloat("Horizontal", 0);
            //    anim.SetFloat("FollowHoriz", 0);
            //    anim.SetFloat("FollowVert", distY);
                
            //}
            //if(Mathf.Abs(distX) == Mathf.Abs(distY))
            //{
            //    anim.SetFloat("Vertical", 0);
            //    anim.SetFloat("Horizontal", 0);
            //    anim.SetFloat("FollowVert", 0);
            //    anim.SetFloat("FollowHoriz", 0);
            //}
        }

    }
}
