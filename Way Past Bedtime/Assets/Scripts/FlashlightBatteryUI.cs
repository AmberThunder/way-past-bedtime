using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightBatteryUI : MonoBehaviour
{

    public Image flashlightOn;
    public Image flashlightOff;
    public Image flashlightBarFill;

    //public GameObject flashlight;

    FlashLightController flashlightController;

    // Start is called before the first frame update
    void Start()
    {

        flashlightController = FindObjectOfType<FlashLightController>();//flashlight.GetComponent<FlashLightController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flashlightController.batteryLife <= 0)
        {
            flashlightOn.gameObject.SetActive(false);
            flashlightOff.gameObject.SetActive(true);
        } else
        {
            flashlightOn.gameObject.SetActive(true);
            flashlightOff.gameObject.SetActive(false);
        }

        flashlightBarFill.transform.localScale = new Vector3(0 + (flashlightController.batteryLife / 100f), flashlightBarFill.transform.localScale.y, flashlightBarFill.transform.localScale.z);
    }
}
