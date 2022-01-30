using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreditsLight : MonoBehaviour
{
    [SerializeField] float angleLimit = 30;
    float angleIncrement = 20;
    float baseAngle = 0;
    bool movingLeft = true;

    private void Start()
    {
        baseAngle = transform.rotation.eulerAngles.z;
        Debug.Log(baseAngle);
    }
    private void Update()
    {
        
        if (movingLeft)
        {
            if (transform.rotation.eulerAngles.z <= baseAngle + angleLimit)
            {

                transform.Rotate(new Vector3(0, 0, angleIncrement) * Time.deltaTime);
                Debug.Log(transform.rotation.eulerAngles);
            }
            else
            {
                movingLeft = !movingLeft;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z >= baseAngle - angleLimit)
            {
                transform.Rotate(new Vector3(0, 0, -angleIncrement) * Time.deltaTime);
                Debug.Log(transform.rotation.eulerAngles);
            }
            else
            {
                movingLeft = !movingLeft;
            }
        }
    }
}
