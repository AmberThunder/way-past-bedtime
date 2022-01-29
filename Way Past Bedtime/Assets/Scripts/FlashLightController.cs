using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLightController : MonoBehaviour
{
    // Start is called before the first frame update

    public Light2D flashlight;

    public float batteryLife = 100f;

    public float batteryLifeDrainSpeed = 5;

    private Controls defaultControls;

    bool active = false;

    LightFlicker flicker;

    private void Awake()
    {
        defaultControls = new Controls();
        flashlight.gameObject.SetActive(active);
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
        flicker = flashlight.GetComponent<LightFlicker>();
        flicker.minFlicker = 1;
    }

    private void ToggleFlashLight(InputAction.CallbackContext context)
    {
        if(batteryLife > 0)
        {
            active = !active;
            flashlight.gameObject.SetActive(active);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            if(batteryLife - (batteryLifeDrainSpeed * Time.deltaTime) <= 0)
            {
                batteryLife = 0;
                active = false;
                flashlight.gameObject.SetActive(active);
            } else
            {
                batteryLife = batteryLife - (batteryLifeDrainSpeed * Time.deltaTime);
            }

            if (batteryLife < 50)
            {
                flicker.minFlicker = batteryLife / 100f;
            }
        }
    }

}
