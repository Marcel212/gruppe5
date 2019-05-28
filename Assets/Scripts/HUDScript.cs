﻿using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{

    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory.GetComponent<InventoryControll>().ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs item)
    {
        // Bild einfügen
        Transform inventoryPanel = transform.GetChild(0);
        foreach (Transform slot in inventoryPanel)
        {
            
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();

            if (image.sprite == null)
            {
                //image.enabled = true;
                //Ggf. Scriptable Objects entfernen? 
                image.sprite = item.Item.ItemInStore.itemPicuture;
                
            }
            
        }
    }
    
}