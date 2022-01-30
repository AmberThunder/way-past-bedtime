using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlashlightCollisionController : MonoBehaviour
{

    EventManager em;
    // Start is called before the first frame update
    void Start()
    {
        em = GameObject.FindGameObjectWithTag("Event Manager").GetComponent<EventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Wall")
        {
            Vector3 heading = collision.transform.position - transform.position;
            float distance = heading.magnitude;
            Vector3 dir = heading / distance;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance);
            if (hit.collider != null)
            {
               // Debug.DrawLine(this.gameObject.transform.position, hit.collider.transform.position, Color.green, 10f);
                if (hit.collider.gameObject.GetComponent<FlashLightLightUp>() != null)
                {
                    Debug.Log("HAs light up");
                    hit.collider.gameObject.GetComponent<FlashLightLightUp>().LightUp();
                }
            }
        }
    }
}
