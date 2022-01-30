using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLightSprite : MonoBehaviour
{
    SpriteRenderer lightSprite;

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
        lightSprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (lightSprite == null)
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
        lightSprite.color = new Color(100 / (float)smoothQueue.Count, 100 / (float)smoothQueue.Count, 100 / (float)smoothQueue.Count, 1);
    }
}
