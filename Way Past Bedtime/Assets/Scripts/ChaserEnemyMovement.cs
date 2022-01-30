using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyMovement : Enemy
{
    override protected void ContinuousAttack()
    {
        rb2d.velocity = -1 * GetAngleToPlayer() * speed;
    }

    protected override void UpdateAnimation()
    {
        anim.SetBool("Lit", lit);
        anim.SetBool("Attacking", attacking);
    }

    public void EnemyStepSound()
    {
        AudioManager.PlaySoundEffect("teddystep", audiosrc);
    }
}
