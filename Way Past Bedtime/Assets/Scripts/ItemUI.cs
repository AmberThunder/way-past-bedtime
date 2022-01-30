using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] GameObject itemSlot;
    [SerializeField] Transform itemHolder;

    public void AddItem(Sprite sprite)
    {
        GameObject newItemSlot = Instantiate(itemSlot);
        newItemSlot.GetComponentsInChildren<Image>()[1].sprite = sprite;

        newItemSlot.transform.SetParent(itemHolder);
    }
}
