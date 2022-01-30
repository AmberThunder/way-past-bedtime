using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyMovement : Enemy
{
    override protected void MonsterAttack()
    {
        Vector2 angle = GetAngleToPlayer();
        rb2d.MovePosition(angle * speed);
    }

}
