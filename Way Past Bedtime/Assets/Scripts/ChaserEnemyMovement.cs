using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyMovement : Enemy
{
    override protected void ContinuousAttack()
    {
        rb2d.velocity = -1 * GetAngleToPlayer() * speed;
    }

}
