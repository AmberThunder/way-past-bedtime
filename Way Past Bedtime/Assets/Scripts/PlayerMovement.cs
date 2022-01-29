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

    Camera cam;

    public void OnPlayerMovement(InputAction.CallbackContext context)
    {
        rb2d.velocity = context.ReadValue<Vector2>() * speed;
    }

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {

    }

    
}
