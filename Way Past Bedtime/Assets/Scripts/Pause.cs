using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    static GameObject menu = null;
    static public bool paused = false;

    public static void TogglePause()
    {
        if (!paused)
        {
            paused = true;

            menu = Instantiate(Resources.Load<GameObject>("Prefabs/Pause Canvas"));
        }
        else
        {
            paused = false;
            Destroy(menu);
        }
    }
}
