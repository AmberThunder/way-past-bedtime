using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightCollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Walls")
        {
            Vector3 heading = collision.transform.position - transform.position;
            float distance = heading.magnitude;
            Vector3 dir = heading / distance;
            Debug.DrawRay(transform.position, collision.transform.position - transform.position, Color.red, 100f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance);
            if (hit.collider != null && hit.collider.tag != "Walls")
            {
                if(hit.collider == collision)
                {
                    Debug.Log("AYO");
                }
            }
        }
    }
}
