using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteInLight : MonoBehaviour
{

    public Sprite inLight;
    public Sprite inDark;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = inDark;
        if(this.GetComponent<BoxCollider2D>() == null)
        {
            this.gameObject.AddComponent<BoxCollider2D>();
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Flashlight")) {
            this.GetComponent<SpriteRenderer>().sprite = inLight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flashlight"))
        {
            this.GetComponent<SpriteRenderer>().sprite = inDark;
        }
    }


}
