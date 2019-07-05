using System;
using System.Collections.Generic;
using UnityEngine;
public class InventoryControll : MonoBehaviour
{
    //Inventar & HotKey Intern
    [SerializeField] private List<ItemAndAmount> itemsInInventory;
    [SerializeField] private List<ItemAndAmount> itemsInHotkeys;

    [SerializeField] private ItemAndAmount[] itemsInCrafting;
    //Parents der Slots zum finden der Scripte
    [SerializeField] private Transform itemsParentInventory;
    [SerializeField] private Transform itemsParentHotkeyPanel;
    [SerializeField] private Transform itemsParentHotKeyOnScreen;
    [SerializeField] private Transform itemsParentCrafting;

    //InventarSlots im UI
    private ItemSlots[] itemSlotsInventory;
    private ItemSlots[] itemSlotsHotKey;
    private ItemSlots[] itemSlotsHotKeyOnScreen;
    private ItemSlots[] itemSlotsCrafting;

    public bool[] enoughItemsForCraftingSmall = new bool[5];
   // public bool[] enoughItemsForCraftingBig= new bool[10];
    
    [SerializeField] public ScriptableManagerScript manager;

    Item value = null;
    private void OnValidate()
    {
        //Legt eine Liste mit allen ItemSlotScript an
        if (itemsParentInventory != null)
        {
            itemSlotsInventory = itemsParentInventory.GetComponentsInChildren<ItemSlots>();
        }

        if (itemsParentHotkeyPanel != null)
        {
            itemSlotsHotKey = itemsParentHotkeyPanel.GetComponentsInChildren<ItemSlots>();
        }

        if (itemsParentHotKeyOnScreen != null)
        {
            itemSlotsHotKeyOnScreen = itemsParentHotKeyOnScreen.GetComponentsInChildren<ItemSlots>();
        }

        if (itemsParentCrafting != null)
        {
            itemSlotsCrafting = itemsParentCrafting.GetComponentsInChildren<ItemSlots>();
        }

        // Übergebe allen ItemSlots ihren index und ihr Placement
        for (int i = 0; i < itemSlotsInventory.Length; i++)
        {
            itemSlotsInventory[i].indexInPlacement = i;
            itemSlotsInventory[i].placement = DropZone.Placement.Inventory;
        }

        for (int i = 0; i < itemSlotsHotKey.Length; i++)
        {
            itemSlotsHotKey[i].indexInPlacement = i;
            itemSlotsHotKey[i].placement = DropZone.Placement.Hotkeys;

            itemSlotsHotKeyOnScreen[i].indexInPlacement = i;
            itemSlotsHotKeyOnScreen[i].placement = DropZone.Placement.Hotkeys;
        }

        for (int i = 0; i < itemSlotsCrafting.Length; i++)
        {
            itemSlotsCrafting[i].indexInPlacement = i;
            itemSlotsCrafting[i].placement = DropZone.Placement.Crafting;
        }

        EnoughItemsForCraftingSmall = enoughItemsForCraftingSmall;
        RefreshInventory();

    }

    public bool[] EnoughItemsForCraftingSmall
    {
        get
        {
            return enoughItemsForCraftingSmall;
        }

        set
        {
            enoughItemsForCraftingSmall = value;

            for (int index = 0; index < enoughItemsForCraftingSmall.Length; index++)
            {
                var tempColor = itemSlotsCrafting[index]._currentImage.color;
                if (!enoughItemsForCraftingSmall[index]){  tempColor.a = 0.5f;} else { tempColor.a = 1f; }
                itemSlotsCrafting[index]._currentImage.color = tempColor;
            }
            RefreshInventory();
        }
    }

    
    /*//TODO WHAT? 
    public bool[] EnoughItemsForCraftingBig
    {
        get { return enoughItemsForCraftingBig; }
        set
        {
            enoughItemsForCraftingBig = value; 
            for (int index = 0; index < enoughItemsForCraftingSmall.Length; index++)
            {
                var tempColor = itemSlotsCrafting[index]._currentImage.color;
                if (!enoughItemsForCraftingSmall[index]){  tempColor.a = 0.5f;} else { tempColor.a = 1f; }
                itemSlotsCrafting[index]._currentImage.color = tempColor;
            }
            RefreshUi();
        }
    }*/

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            manager._dictionary.TryGetValue("Erde", out value);

            AddItem(value);
        }

        if (Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            RemoveItemPack(0, DropZone.Placement.Inventory);
        }
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
        
    }

    //Soll aufgerufen werden, wenn sich etwas im Inventar ändert
    //Bindet die Liste an Items an die ItemSlots
    public void RefreshInventory()
    {
        // Passe alle UI Elemente an die Liste der InventarElemente an
        int i = 0;
        for (; i < itemsInInventory.Count & i < itemSlotsInventory.Length; i++)
        {
            itemSlotsInventory[i].Amount = itemsInInventory[i].amount;
            itemSlotsInventory[i].Item = itemsInInventory[i].item;
        }

        for (; i < itemSlotsInventory.Length; i++)
        {
            itemSlotsInventory[i].Amount = 0;
            itemSlotsInventory[i].Item = null;
        }
        // Passe alle UI Elemente an die Liste der HotKeyElemente an
        int j = 0;
        int currentAmount;
        Item currentItem;

        for (; j < itemsInHotkeys.Count & j < itemSlotsHotKey.Length; j++)
        {
            currentAmount = itemsInHotkeys[j].amount;
            currentItem = itemsInHotkeys[j].item;

            itemSlotsHotKey[j].Amount = currentAmount;
            itemSlotsHotKey[j].Item = currentItem;

            itemSlotsHotKeyOnScreen[j].Amount = currentAmount;
            itemSlotsHotKeyOnScreen[j].Item = currentItem;

        }

        for (; j < itemSlotsHotKey.Length; j++)
        {
            currentAmount = 0;
            currentItem = null;

            itemSlotsHotKey[j].Amount = currentAmount;
            itemSlotsHotKey[j].Item = currentItem;
            itemSlotsHotKeyOnScreen[j].Amount = 0;
            itemSlotsHotKeyOnScreen[j].Item = currentItem;
        }

        int k = 0;
        for (; k < itemsInCrafting.Length & k < itemSlotsCrafting.Length; k++)
        {
            itemSlotsCrafting[k].Amount = itemsInCrafting[k].amount;
            itemSlotsCrafting[k].Item = itemsInCrafting[k].item;
        }

        for (; k < itemSlotsCrafting.Length; k++)
        {
            itemSlotsCrafting[k].Amount = 0;
            itemSlotsCrafting[k].Item = null;
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
            RefreshInventory();
            return true;

        }
        else
        {
            return false;
        }

    }

    public bool SwapItems(int startIndex, DropZone.Placement startPlacement, int endIndex, DropZone.Placement endPlacement)
    {
        bool validStartIndex = startIndex > -1 // mindestens index 0
                               && ((startPlacement == DropZone.Placement.Inventory &&
                                    startIndex < itemSlotsInventory.Length
                                   )
                                   || (startPlacement == DropZone.Placement.Hotkeys &&
                                       startIndex < itemSlotsHotKey.Length
                                   )
                                   || (startPlacement == DropZone.Placement.Crafting && startIndex < 5));

        Debug.Log("Startindex Ok? " + startIndex + " in " + startPlacement + " ist " + validStartIndex);

        bool validEndIndex = endIndex > -1
                             && ((endPlacement == DropZone.Placement.Inventory && endIndex < itemSlotsInventory.Length)
                                 || (endPlacement == DropZone.Placement.Hotkeys && endIndex < itemSlotsHotKey.Length)
                                 || (endPlacement == DropZone.Placement.Crafting && endIndex < 4));


        Debug.Log("EndIndex Ok? " + endIndex + " in " + endPlacement + " ist " + validEndIndex);

        ItemAndAmount temp;
        if (validStartIndex && validEndIndex)
        {
            if (startPlacement == DropZone.Placement.Inventory && endPlacement == DropZone.Placement.Inventory)
            {
                temp = itemsInInventory[startIndex];
                itemsInInventory[startIndex] = itemsInInventory[endIndex];
                itemsInInventory[endIndex] = temp;

            } else if (startPlacement == DropZone.Placement.Inventory && endPlacement == DropZone.Placement.Hotkeys)
            {
                temp = itemsInInventory[startIndex];
                itemsInInventory[startIndex] = itemsInHotkeys[endIndex];
                itemsInHotkeys[endIndex] = temp;
            } else if (startPlacement == DropZone.Placement.Inventory && endPlacement == DropZone.Placement.Crafting)
            {
                temp = itemsInInventory[startIndex];
                itemsInInventory[startIndex] = itemsInCrafting[endIndex];
                itemsInCrafting[endIndex] = temp;
            } else if (startPlacement == DropZone.Placement.Hotkeys && endPlacement == DropZone.Placement.Inventory)
            {
                temp = itemsInHotkeys[startIndex];
                itemsInHotkeys[startIndex] = itemsInInventory[endIndex];
                itemsInInventory[endIndex] = temp;
            } else if (startPlacement == DropZone.Placement.Hotkeys && endPlacement == DropZone.Placement.Hotkeys)
            {
                temp = itemsInHotkeys[startIndex];
                itemsInHotkeys[startIndex] = itemsInHotkeys[endIndex];
                itemsInHotkeys[endIndex] = temp;
            }
            RefreshInventory();

            return true;
        }
        else
        {
            return false;
        }
    }


    public bool RemoveItemPack(int index, DropZone.Placement placement)
    {
        bool indexValid = index > -1
                          && ((placement == DropZone.Placement.Inventory && index < itemSlotsInventory.Length)
                              || (placement == DropZone.Placement.Hotkeys && index < itemSlotsHotKey.Length));
        if (indexValid)
        {
            if (placement == DropZone.Placement.Inventory)
            {
                itemsInInventory[index].item = null;
                itemsInInventory[index].amount = 0;
            } else if (placement == DropZone.Placement.Hotkeys)
            {
                itemsInHotkeys[index].item = null;
                itemsInHotkeys[index].amount = 0;
            }
            RefreshInventory();
            return true;
        }

        return false;
    }

    public bool RemoveOneItemInHotKey(int index)
    {
        bool indexValid = index > -1 && (index < itemSlotsHotKey.Length);
        bool returnvalue =false;
        if (indexValid)
        {
            if(itemsInHotkeys[index].amount > 0 && itemsInHotkeys[index].item != null)
            {
                itemsInHotkeys[index].amount--;
                returnvalue = true;
            }

            //Löscht bei 0 das Item
            if(itemsInHotkeys[index].amount == 0)
            {
                itemsInHotkeys[index].item = null;
            }
           
            
            RefreshInventory();

        }
       
        Debug.Log(returnvalue);
        return returnvalue;
    }

    public bool RemoveItemInInventory(Item item)
    {
        List<ItemAndAmount> itemAndAmountOutput;
        List<int> indices;

        if(InventoryContainsItem(item, out itemAndAmountOutput, out indices) && itemAndAmountOutput[0].amount>0)
        {
            itemsInInventory[indices[0]].amount--;

            //Löscht bei 0 das Item
            if (itemsInInventory[indices[0]].amount == 0)
            {
                itemsInInventory[indices[0]].item = null;
            }
            return true;
        }


       
        RefreshInventory();
        return false;
        

    }

    public void ClearCraftingField(bool craft)
    {
        int i = 0;
        for ( i = 0; i < itemsInCrafting.Length-1; i++)
        {
            if (!craft)
            {
                AddItem(itemsInCrafting[i].item);
            }
            itemsInCrafting[i].item = null;
            itemsInCrafting[i].amount = 0;
        }

        if (craft)
        {
            int amount = itemsInCrafting[i].amount;
            for (int counter = 0; counter < amount; counter++)
            {
                AddItem(itemsInCrafting[i].item);                
            }
        }
        itemsInCrafting[i].item = null;
        itemsInCrafting[i].amount = 0;
        RefreshInventory();
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
        if (item == null)
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
            if (indexInList == -1 && InventoryContainsItem(null, out itemAndAmountOutput, out indicesOfResult))
            {
                indexInList = indicesOfResult[0];
                result = true;
            }

        }

        return result;
    }

    public List<Item> GetItemsInHotkey()
    {
        List<Item> resultList = new List<Item>();
        foreach (var item in itemsInHotkeys)
        {
            resultList.Add(item.item);
        }
        return resultList;
    }

    

    public ItemAndAmount[] ItemsInCrafting{
        get
        {
            return itemsInCrafting;
        }

        set
        {
            itemsInCrafting = value;
            RefreshInventory();
        }
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
    
    
}

