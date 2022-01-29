using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{

    Light2D light2d;

    public float minFlicker = 0f;
    public float maxFlicker = 1f;

    [Range(1, 50)]
    public int smoothing = 1;

    Queue<float> smoothQueue;
    float lastSum = 0;

    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
        light2d = GetComponent<Light2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (light2d == null)
            return;

        // pop off an item if too big
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate random new item, calculate new average
        float newVal = Random.Range(minFlicker, maxFlicker);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Calculate new smoothed average
        light2d.intensity = lastSum / (float)smoothQueue.Count;
    }
}
