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
    Vector2 mousePos;

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
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        rb2d.rotation = angle;
    }
}
