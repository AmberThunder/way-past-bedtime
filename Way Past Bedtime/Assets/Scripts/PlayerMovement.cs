using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls the player's movement
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed = 5;
    Animator anim;

Camera cam;

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        rb2d.velocity = context.ReadValue<Vector2>() * speed;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(rb2d.velocity.magnitude < .1f)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
            anim.SetFloat("Horizontal", rb2d.velocity.x);
            anim.SetFloat("Vertical", rb2d.velocity.y);
        }
    }

    
}
