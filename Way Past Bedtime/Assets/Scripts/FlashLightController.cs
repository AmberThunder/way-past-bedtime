using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    // Start is called before the first frame update

    public Light2D flashlight;

    private Controls defaultControls;

    Rigidbody2D rb2d;
    Camera cam;
    Vector2 mousePos;

    bool active = false;

    private void Awake()
    {
        defaultControls = new Controls();
        flashlight.gameObject.SetActive(active);
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnEnable()
    {
        defaultControls.Enable();
    }

    private void OnDisable()
    {
        defaultControls.Disable();
    }

    void Start()
    {
        defaultControls.Newactionmap.Flashlight.performed += ToggleFlashLight;
    }

    private void ToggleFlashLight(InputAction.CallbackContext context)
    {
        active = !active;
        flashlight.gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }

}
