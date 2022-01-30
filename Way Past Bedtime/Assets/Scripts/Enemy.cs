using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public float runTime = 2;
    public float pauseTime = .5f;
    public float detectionRange = 20;
    public bool attacking = false;
    public bool stopped = false;
    protected GameObject player;
    protected Rigidbody2D rb2d;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        stopped = true;
        StartCoroutine(Pause());
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped && !attacking)
        {
            CheckForPlayer();
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(pauseTime);
        stopped = false;
    }

    IEnumerator Attack()
    {
        MonsterAttack();
        yield return new WaitForSeconds(pauseTime);
        attacking = false;
        StartCoroutine(Pause());
    }

    void CheckForPlayer()
    {
        if ((transform.position - player.transform.position).magnitude < detectionRange)
        {
            StartCoroutine(Attack());
        }
        else
        {
            StartCoroutine(Pause());
        }
    }

    protected Vector2 GetAngleToPlayer()
    {
        return (rb2d.position - new Vector2(player.transform.position.x, player.transform.position.y)).normalized;
    }

    protected virtual void MonsterAttack()
    {
        //generic
    }
}
