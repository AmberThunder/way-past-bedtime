using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroll : MonoBehaviour
{
    [SerializeField] float increment;
    float totalMovement;
    float height = 0;
    private void Start()
    {
        height = GetComponent<RectTransform>().sizeDelta.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y + increment*Time.deltaTime, 0);
        totalMovement += increment * Time.deltaTime;

        if (totalMovement >= height)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
