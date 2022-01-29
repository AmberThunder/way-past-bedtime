using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    // Start is called before the first frame update

    public Light2D flashlight;

    public GameObject lightCollider;

    private Controls defaultControls;

    bool active = false;

    private void Awake()
    {
        defaultControls = new Controls();
        flashlight.gameObject.SetActive(active);
        lightCollider.SetActive(active);
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
        lightCollider.SetActive(active);

    }

    // Update is called once per frame
    void Update()
    {

    }

}
