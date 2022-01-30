using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play sounds even when the scene changes
/// </summary>
public class GlobalSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
