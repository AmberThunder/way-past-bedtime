using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    public float runTime = 1;
    public float pauseTime = 1;
    public float detectionRange = 20;
    public bool attacking = false;
    public bool stopped = false;
    public bool lit = false;

    protected GameObject player;
    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected SpriteRenderer rend;
    protected AudioSource audiosrc;

    public Material unlitMat;
    public Material litMat;

    bool inLight;

    AudioSource asource;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        audiosrc = GetComponent<AudioSource>();
        stopped = true;
        StopAllCoroutines();
        StartCoroutine(Pause());
        asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!lit && !stopped && !attacking)
        {
            CheckForPlayer();
        }
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if(attacking && !stopped)
        {
            ContinuousAttack();
        }

        if (inLight)
        {
            //Debug.Log("In light");
            int layerMaskPlayer = 1 << LayerMask.NameToLayer("PlayerRayCast");
            int layerMaskWall = 1 << LayerMask.NameToLayer("Wall");
            int layerMask = layerMaskPlayer | layerMaskWall;
            //Physics2D.queriesHitTriggers = false;
            Vector3 heading = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
            float distance = heading.magnitude;
            Vector3 dir = heading / distance;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, Mathf.Infinity, layerMask);
            if (hit.collider != null )
            {
                if(hit.collider.gameObject.tag == "PlayerRayCastHit")
                {
                    EnemyInLight();
                    //Debug.DrawLine(this.gameObject.transform.position, hit.collider.transform.position, Color.red, 10f);
                } else
                {
                    EnemyNotInLight();
                    //Debug.DrawLine(this.gameObject.transform.position, hit.collider.transform.position, Color.green, 10f);
                    //Debug.Log("Hitting " + hit.collider.gameObject.name);
                }
            }
        }
    }

    private void Awake()
    {
        //EventManager.collide += LightUp;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(pauseTime);
        stopped = false;
    }

    IEnumerator Attack()
    {
        FacePlayer();
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
        //Debug.Log("Single Attack");
    }

    protected virtual void UpdateAnimation()
    {
        //fill in here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flashlight"))
        {
            inLight = true;
        }
        else if (collision.gameObject.tag.Equals("Bat"))
        {
            AudioManager.PlaySoundEffect("bonk", asource);
            StopAllCoroutines();
            stopped = true;
            attacking = false;
            rb2d.velocity = GetAngleToPlayer() * 30;
            StartCoroutine(Pause());
        }
    }

    void EnemyInLight()
    {
        StopAllCoroutines();
        rend.material = litMat;
        lit = true;
        stopped = true;
        attacking = false;
    }

    void EnemyNotInLight()
    {
        rend.material = unlitMat;
        lit = false;
        stopped = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flashlight"))
        {
            inLight = false;
            EnemyNotInLight();
        }
    }

    protected void FacePlayer()
    {
        rend.flipX = player.transform.position.x > transform.position.x;
    }
}