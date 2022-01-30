using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemCollector script = collision.gameObject.GetComponent<ItemCollector>();

        if (script != null && script.CheckItems())
        {
            // win the game
            Debug.Log("Win the game");
            Instantiate(Resources.Load<GameObject>("Prefabs/Win Canvas"));
        }
    }
}
