using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    private Controls defaultControls;
    Animator anim;

    public float attackTime = 2f;
    float attackCooldown = 0f;
    float hitBoxCooldown = 0f;

    public float batHitBoxTime = 0.5f;

    float lastHor = -1f;
    float lastVert = -1f;

    public GameObject batHitBox;

    AudioSource asource;

    private void Awake()
    {
        defaultControls = new Controls();
    }
    private void OnEnable()
    {
        defaultControls.Enable();
    }

    private void OnDisable()
    {
        defaultControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultControls.Newactionmap.Wack.performed += Wack;
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackCooldown <= 0)
        {
            attackCooldown = 0f;
        } else
        {
            attackCooldown -= 1 * Time.deltaTime;
        }

        if(hitBoxCooldown <= 0)
        {
            hitBoxCooldown = 0f;
            batHitBox.transform.rotation = Quaternion.identity;
            batHitBox.SetActive(false);
        } else
        {
            hitBoxCooldown -= 1 * Time.deltaTime;
        }

        if(anim.GetBool("Moving"))
        {
            lastHor = anim.GetFloat("Horizontal");
            lastVert = anim.GetFloat("Vertical");
        }
    }

    private void Wack(InputAction.CallbackContext context)
    {

        if (attackCooldown == 0f)
        {
            anim.SetTrigger("Wack");
            attackCooldown = attackTime;
            if(lastVert < 0)
            {
                //Attack down
                ThrowHitbox(0);
            } else if (lastVert > 0)
            {
                //Attack up
                ThrowHitbox(1);
            } else
            {
                if (lastHor < 0)
                {
                    //Attack left
                    ThrowHitbox(2);
                }
                else
                {
                    //Attack right
                    ThrowHitbox(3);
                }
            }
        }
        
    }

    void ThrowHitbox(int dir)
    {
        AudioManager.PlaySoundEffect("batswing", asource);
        //Dir 0 = down 1 = up 2 = left 3 = right
        batHitBox.SetActive(true);
        switch(dir)
        {
            case 1:
                batHitBox.transform.Rotate(0, 0, 180f);
                break;
            case 2:
                batHitBox.transform.Rotate(0, 0, 270f);
                break;
            case 3:
                batHitBox.transform.Rotate(0, 0, 90f);
                break;
            default:
                break;
        }
        hitBoxCooldown = batHitBoxTime;
    }

}
