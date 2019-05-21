using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryControll : MonoBehaviour
{

    public const int SLOTS = 35;
    
    public List<IInventoryItem> itemsInInventory = new List<IInventoryItem>();

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

