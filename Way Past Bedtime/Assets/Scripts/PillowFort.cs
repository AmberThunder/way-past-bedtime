using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowFort : MonoBehaviour
{
    Transform player;
    float pillowSpeed = 8;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void MonsterAttack()
    {
        GameObject pillow = Instantiate(Resources.Load<GameObject>("Prefabs/Pillow"), transform.position, Quaternion.identity);

        pillow.GetComponent<Rigidbody2D>().velocity = GetAngleToPlayer() * pillowSpeed;
               
    }
}
