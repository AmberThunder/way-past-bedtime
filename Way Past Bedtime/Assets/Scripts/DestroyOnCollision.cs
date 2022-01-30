using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] GameObject particle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if (particle != null)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}
