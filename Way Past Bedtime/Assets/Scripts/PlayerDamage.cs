using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerDamage : MonoBehaviour
{
    Light2D[] lights;
    float fadeAmount = 0.1f;
    AudioSource audiosrc;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spooky")
        {
            Debug.Log("spooky");

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy == null || enemy.lit == false)
            {
                ///health--;
                //if (health <= 0) { StartCoroutine(OnPlayerFaint()); }
                StartCoroutine(OnPlayerFaint());
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<Light2D>();
        audiosrc = GetComponent<AudioSource>();
        
    }

    IEnumerator OnPlayerFaint()
    {
        FindObjectOfType<FlashLightController>().batteryLife = 0;
        GetComponent<SpriteRenderer>().enabled = false;
        //AudioManager.PlaySoundEffect("tommyhit", audiosrc);
        //AudioManager.PlaySoundEffect("tommycry", audiosrc);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
