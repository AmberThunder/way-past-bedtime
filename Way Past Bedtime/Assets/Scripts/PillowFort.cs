using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowFort : Enemy
{
    float pillowSpeed = 9;


    /// <summary>
    /// Throw a throw pillow at the player
    /// </summary>
    override protected void SingleAttack()
    {
        
        GameObject pillow = Instantiate(Resources.Load<GameObject>("Prefabs/Pillow"), transform.position, Quaternion.identity);

        pillow.GetComponent<Rigidbody2D>().velocity = -GetAngleToPlayer() * pillowSpeed;

    }

    override protected void ContinuousAttack()
    {
        rb2d.velocity = -1 * GetAngleToPlayer() * speed;
    }

    protected override void UpdateAnimation()
    {
        anim.SetBool("Lit", lit);
        anim.SetBool("Attacking", attacking);
    }
}
