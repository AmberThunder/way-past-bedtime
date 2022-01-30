using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowFort : Enemy
{
    float pillowSpeed = 8;


    /// <summary>
    /// Throw a throw pillow at the player
    /// </summary>
    override protected void SingleAttack()
    {
        
        GameObject pillow = Instantiate(Resources.Load<GameObject>("Prefabs/Pillow"), transform.position, Quaternion.identity);

        pillow.GetComponent<Rigidbody2D>().velocity = -GetAngleToPlayer() * pillowSpeed;

    }
}
