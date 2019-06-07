using System;
using System.Collections.Generic;
using UnityEngine;
public class InventoryControll : MonoBehaviour
{
    //Inventar Intern
    [SerializeField] private List<ItemAndAmount> itemsInInventory;

    [SerializeField] private Transform itemsParent;
    //Inventar im UI
    [SerializeField] private ItemSlots[] itemSlots;

    [SerializeField] private ScriptableManagerScript manager; 
    
    Item value = null;
    private void OnValidate()
    {
        //Legt eine Liste mit allen ItemSlotScript an
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();
        }
        
        
        RefreshUi();
        
    }

    public string PrintListInt(List<int> testList)
    {
        string result = "[ ";
        foreach (var i in testList)
        {
            result = result + " " +  i + ",";
        }

        result = result + " ]";
        return result; 
    }

    public string PrintItemAndAmountList(List<ItemAndAmount> testList)
    {
        string result = "[ ";
        foreach (var item in testList)
        {
            result = result + "(" + item.item + ", " + item.amount + ") ;";
        }

        result = result + " ]";
        return result;
    }
    
    
    private void Start()
    {
        List<ItemAndAmount> testList = new List<ItemAndAmount>();
        List<int> testIndices = new List<int>();
       
        int index = -2;
        manager._dictionary.TryGetValue("Erde", out value);
        Debug.Log("Erde enthalten? " + InventoryContainsItem(value, out testList, out testIndices) + " IndicesListe: " + PrintListInt(testIndices));
        Debug.Log("Möglicher Index für Erde " + IsStillRoomForItem(value, out index) + "   " + index);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            AddItem(value);
        }
    }

    //Soll aufgerufen werden, wenn sich etwas im Inventar ändert
    //Bindet die Liste an Items an die ItemSlots
    public void RefreshUi()
    {
        int i = 0;
        for (; i < itemsInInventory.Count & i < itemSlots.Length; i++)
        {
            itemSlots[i].Amount = itemsInInventory[i].amount;
            itemSlots[i].Item = itemsInInventory[i].item;
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Amount = 0;
            itemSlots[i].Item = null;
        }
    }
    public event EventHandler<InventoryEventArgs> ItemAdded;
    
    //TODO Mehr als ein Item muss eingefügt werden
    public bool AddItem(Item item)
    {
        int index = -1;
        bool canInsert = IsStillRoomForItem(item, out index);
        if (canInsert)
        {
            if (itemsInInventory[index].item == item)
            {
                itemsInInventory[index].amount++;
            }
            else
            {
                itemsInInventory[index].item = item;
                itemsInInventory[index].amount = 1;
            }
            RefreshUi();
            return true;
            
        }
        else
        {
            return false;
        }
        
    }
    
//TODO Statt Löschen Counter erneuern
    public bool RemoveItemPack(ItemAndAmount itemAndAmount)
    {
        if(itemsInInventory.Remove(itemAndAmount))
        {
            RefreshUi();
            return true;
        }else
        {
            return false;
        }
    }

    //Gibt eine Liste an ItemAndAmount Objekten zurück, die das angefragte Item enthalten
    public bool InventoryContainsItem(Item item, out List<ItemAndAmount> itemAndAmountOutput, out List<int> indices)
    {
        itemAndAmountOutput = new List<ItemAndAmount>();
        indices = new List<int>();
        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            if (itemsInInventory[i].item == item)
            {
                itemAndAmountOutput.Add(itemsInInventory[i]);
                indices.Add(i);
            }
        }
        return itemAndAmountOutput.Count != 0;
    }
    
    //Überprüft, ob ein Item dieses Typs noch reinpasst
    //IndexInList gibt -1 zurück, falls kein Platz mehr ist, ansonsten den Index an dem Platz ist
    public bool IsStillRoomForItem(Item item, out int indexInList)
    {
        indexInList = -1;
        bool result = false;
        //Wenn das Item null ist wird immer false zurückgegeben;
        if (item.Equals(null))
        {
            return false;
        }
        
        List<ItemAndAmount> itemAndAmountOutput = new List<ItemAndAmount>();
        List<int> indicesOfResult = new List<int>();
       
        
        //Testet, ob das Inventar schon Stapel dieses Items besitzt
        if (InventoryContainsItem(item, out itemAndAmountOutput, out indicesOfResult))
        {    
            //Prüft, ob alle Stapel voll sind
            for (var i = 0; i < itemAndAmountOutput.Count; i++)
            {
                //übergibt den zugehörigen Index
                if (itemAndAmountOutput[i].amount < 64)
                {
                    indexInList = indicesOfResult[i];
                    result = true;
                }
            }
        }
        // Wenn ein Platz ohne Item existiert ist immer noch Platz, gibt zusätzlich den Platz des ersten freien Index aus

        if (!result)
        {
            if (indexInList == -1 &&InventoryContainsItem(null, out itemAndAmountOutput, out indicesOfResult))
            {
                indexInList = indicesOfResult[0];
                result = true;
            }
            
        }

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

