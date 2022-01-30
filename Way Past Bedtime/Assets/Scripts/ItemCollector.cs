using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{
    int items = 0;
    int totalItems = 0;
    AudioSource asource;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            AudioManager.PlaySoundEffect("tingling", asource);
            items++;
            FindObjectOfType<ItemUI>().AddItem(collision.gameObject.GetComponent<SpriteRenderer>().sprite);
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;
        asource = GetComponent<AudioSource>();
        
    }

    public bool CheckItems()
    {
        return items >= totalItems;
    }
}
