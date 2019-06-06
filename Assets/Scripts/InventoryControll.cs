using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class InventoryControll : MonoBehaviour
{
    //Inventar Intern
    [SerializeField] private List<ItemAndAmount> itemsInInventory;

    [SerializeField] private Transform itemsParent;
    //Inventar im UI
    [SerializeField] private ItemSlots[] _itemSlots;

    [SerializeField] private ScriptableManagerScript manager; 
    
    private void OnValidate()
    {
        //Legt eine Liste mit allen ItemSlotScript an
        if (itemsParent != null)
        {
            _itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();
        }
        
        RefreshUI();
        
    }


    private void Start()
    {
        Item value = null;
        manager._dictionary.TryGetValue("Erde", out value);
        Debug.Log("Erde voll? " + IsFull(value));  
    }

    //Soll aufgerufen werden, wenn sich etwas im Inventar ändert
    //Bindet die Liste an Items an die ItemSlots
    public void RefreshUI()
    {
        int i = 0;
        for (; i < itemsInInventory.Count & i < _itemSlots.Length; i++)
        {
            _itemSlots[i].Amount = itemsInInventory[i].amount;
            _itemSlots[i].Item = itemsInInventory[i].item;
        }

        for (; i < _itemSlots.Length; i++)
        {
            _itemSlots[i].Amount = 0;
            _itemSlots[i].Item = null;
        }
    }
    public event EventHandler<InventoryEventArgs> ItemAdded;

//TODO Statt hinzufügen ggf. Counter erneuern
    public bool AddItem(Item item)
    {
        if (IsFull(item))
        {
            return false;
        }
        else
        {
           // itemsInInventory.Add(new);
            RefreshUI();
            return true;
        }
    }
    /*
//TODO Statt Löschen Counter erneuern
    public bool RemoveItem(Item item)
    {
        if(itemsInInventory.Remove(item))
        {
            RefreshUI();
            return true;
        }else
        {
            return false;
        }
    }*/

    //Gibt eine Liste an ItemAndAmount Objekten zurück, die das angefragte Item enthalten
    public bool InventoryContainsItem(Item item, out List<ItemAndAmount> itemAndAmountOutput)
    {
        itemAndAmountOutput = new List<ItemAndAmount>();
        
        foreach (var itemAndAmount in itemsInInventory)
        {
            if (itemAndAmount.item == item)
            {
                itemAndAmountOutput.Add(itemAndAmount);
            }
        }
        return itemAndAmountOutput.Count != 0;
    }
    
    //Überprüft, ob ein Item dieses Typs noch reinpasst
    public bool IsFull(Item item)
    {
        if (item == null)
        {
            return true;
        Debug.Log("null");
        }
        bool result = true;
        List<ItemAndAmount> itemAndAmountOutput = new List<ItemAndAmount>();
        if (InventoryContainsItem(item, out itemAndAmountOutput))
        {
            foreach (var itemAndAmount in itemAndAmountOutput)
            {
                result = result && itemAndAmount.amount >= 64;
                Debug.Log("Zwischenergebnis: " +result);
            }
        }
        
        //TODO Count funktioniert hierbei nicht. Erkennt trotzdem items, da Value oder Item definiert sind. 
        Debug.Log(itemsInInventory.Count +" >= " + _itemSlots.Length);
        result = result && itemsInInventory.Count >= _itemSlots.Length;
        return result;
    }
    
    
    // Toter Code eventuell noch wichtig 
    /*public void AddItem(Item item)
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
    }*/
}

