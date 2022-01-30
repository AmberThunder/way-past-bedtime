using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    [SerializeField] float deathDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }
}
