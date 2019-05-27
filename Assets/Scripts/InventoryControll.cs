using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class InventoryControll : MonoBehaviour
{

    public const int SLOTS = 35;
    [SerializeField] private Transform itemsParent;
    [SerializeField] private List<IInventoryItem> itemsInInventory;
    [SerializeField] private ItemSlots[] _itemSlots;

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            _itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();
        }
    }

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        // Wenn noch Platz ist, füge es an der ersten Stelle ein 
        if (itemsInInventory.Count < SLOTS)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                
                itemsInInventory.Add(item);
                
                item.OnPickUp();
                
            }
        }

        if (ItemAdded != null)
        {
            ItemAdded(this, new InventoryEventArgs(item));
        }
    }
}

