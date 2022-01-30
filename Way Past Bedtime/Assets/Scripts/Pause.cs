using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    static GameObject menu = null;
    static public bool paused = false;

    Controls defaultControls;

    public static void TogglePause()
    {
        AudioSource globalSource = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();


        AudioManager.PlaySoundEffect("buttonclick", globalSource);

        if (!paused)
        {
            paused = true;

            menu = Instantiate(Resources.Load<GameObject>("Prefabs/Pause Canvas"));
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            Destroy(menu);
            Time.timeScale = 1;
        }
    }

    public void TogglePause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        TogglePause();
        Debug.Log("Paused");
    }

    private void OnEnable()
    {
        defaultControls.Enable();
    }

    private void OnDisable()
    {
        defaultControls.Disable();
    }

    void Awake()
    {
        defaultControls = new Controls();
        defaultControls.Newactionmap.Pause.performed += TogglePause;
    }
}
