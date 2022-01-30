using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteInLight : MonoBehaviour
{

    public Sprite inLight;
    public Sprite inDark;
    public bool lit = false;

    // Start is called before the first frame update
    void Start()
    {
        turnSpriteDark();
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
            turnSpriteLight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Flashlight"))
        {
            turnSpriteDark();
        }
    }

    void turnSpriteLight()
    {
        lit = true;
        if (inLight == null)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = inLight;
        }
    }

    void turnSpriteDark()
    {
        lit = false;
        if (inDark == null)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = inDark;
        }
    }


}
