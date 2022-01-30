using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    int items = 0;
    int totalItems = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            items++;
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
    }

    public bool CheckItems()
    {
        return items >= totalItems;
    }
}
