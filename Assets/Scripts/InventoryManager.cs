using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Item> items;

    private void Awake()
    {
        items = new List<Item>();
    }

    private void AjouterItem(Item item)
    {
        items.Add(item);
    }
}
