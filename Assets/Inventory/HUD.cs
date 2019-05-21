using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
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

            if (!image.enabled)
            {
                image.enabled = true;
                //Ggf. Scriptable Objects entfernen? 
                image.sprite = item.Item.ItemInStore.itemPicuture;
                
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
