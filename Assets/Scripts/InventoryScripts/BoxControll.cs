using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControll : MonoBehaviour
{
    [SerializeField] private InventoryControll inventory;

    [SerializeField] private ItemAndAmount[] itemsInBox;
    private ItemSlots[] ItemSlotsInBox;


    public ItemAndAmount[] ItemsInBox
    {
        get { return itemsInBox; }
        set
        {
            itemsInBox = value;
            RefreshBox();
        }
    }

    public ItemAndAmount AddItemsByIndex(ItemAndAmount itemAndAmount, int index)
    {
        ItemAndAmount returnValue = itemsInBox[index];
        itemsInBox[index] = itemAndAmount;
        return returnValue;
    }

    public bool SwapItemsByIndex(int startindex, int endindex)
    {
        bool indexValid = startindex > -1 && startindex < ItemSlotsInBox.Length && endindex > -1 && endindex < ItemSlotsInBox.Length;

        if (indexValid)
        {
            ItemAndAmount temp;
            temp = itemsInBox[startindex];
            itemsInBox[startindex] = itemsInBox[endindex];
            itemsInBox[endindex] = temp; 
        }

        return indexValid; 
    }

    //Zuweisung von CraftingSlots an das Script
    private void OnValidate()
    {
        ItemSlotsInBox = GetComponentsInChildren<ItemSlots>();

        
        for (int i = 0; i < ItemSlotsInBox.Length; i++)
        {
            ItemSlotsInBox[i].indexInPlacement = i;
            ItemSlotsInBox[i].placement = DropZone.Placement.Box;
        }

        RefreshBox();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void RefreshBox()
    {
        int k = 0;
        for (; k < itemsInBox.Length & k < ItemSlotsInBox.Length; k++)
        {
            ItemSlotsInBox[k].Amount = itemsInBox[k].amount;
            ItemSlotsInBox[k].Item = itemsInBox[k].item;
        }

        for (; k < ItemSlotsInBox.Length; k++)
        {
            ItemSlotsInBox[k].Amount = 0;
            ItemSlotsInBox[k].Item = null;
        }
    }

}
