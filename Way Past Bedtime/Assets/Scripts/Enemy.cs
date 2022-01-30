using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public float runTime = 1;
    public float pauseTime = 1;
    public float detectionRange = 20;
    public bool attacking = false;
    public bool stopped = false;
    protected GameObject player;
    protected Rigidbody2D rb2d;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        stopped = true;
        StopAllCoroutines();
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

    private void FixedUpdate()
    {
        if(attacking && !stopped)
        {
            ContinuousAttack();
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(pauseTime);
        stopped = false;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(runTime);
        SingleAttack();
        attacking = false;
        stopped = true;
        StartCoroutine(Pause());
    }

    void CheckForPlayer()
    {
        if ((transform.position - player.transform.position).magnitude < detectionRange)
        {
            attacking = true;
            StopAllCoroutines();
            StartCoroutine(Attack());
        }
        else
        {
            stopped = true;
            StopAllCoroutines();
            StartCoroutine(Pause());
        }
    }

    protected Vector2 GetAngleToPlayer()
    {
        Vector2 playerLocation = player.transform.position;
        return (rb2d.position - playerLocation).normalized;
    }

    protected virtual void ContinuousAttack()
    {
        //Debug.Log("Continuous Attack");
    }

    protected virtual void SingleAttack()
    {
        Debug.Log("Single Attack");
    }
}
