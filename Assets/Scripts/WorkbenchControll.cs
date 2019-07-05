using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControll : MonoBehaviour
{
    [SerializeField] private InventoryControll inventory;

    public ItemAndAmount[] itemsInCrafting;
    
    private ItemSlots[] itemSlotsCrafting;

    public bool[] enoughItemsForCraftingBig= new bool[10];


    private void OnValidate()
    {
        itemSlotsCrafting = GetComponentsInChildren<ItemSlots>();
        
        EnoughItemsForCraftingBig = enoughItemsForCraftingBig;
        RefreshWorkbench();

    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    //TODO WHAT? 
    public bool[] EnoughItemsForCraftingBig
    {
        get { return enoughItemsForCraftingBig; }
        set
        {
            enoughItemsForCraftingBig = value; 
            for (int index = 0; index < enoughItemsForCraftingBig.Length; index++)
            {
                var tempColor = itemSlotsCrafting[index]._currentImage.color;
                if (!enoughItemsForCraftingBig[index]){  tempColor.a = 0.5f;} else { tempColor.a = 1f; }
                itemSlotsCrafting[index]._currentImage.color = tempColor;
            }
            RefreshWorkbench();
        }
    }


    public void RefreshWorkbench()
    {
        // Passe alle UI Elemente an die Liste der InventarElemente an
        int i = 0;
        for (; i < itemsInCrafting.Length & i < itemSlotsCrafting.Length; i++)
        {
            itemSlotsCrafting[i].Amount = itemsInCrafting[i].amount;
            itemSlotsCrafting[i].Item = itemsInCrafting[i].item;
        }
    }
    
    public ItemAndAmount[] ItemsInCrafting{
        get
        {
            return itemsInCrafting;
        }

        set
        {
            itemsInCrafting = value;
            RefreshWorkbench();
            inventory.RefreshInventory();
        }
    }
    
    public void ClearCraftingField(bool craft)
    {
        int i = 0;
        for ( i = 0; i < itemsInCrafting.Length-1; i++)
        {
            if (!craft)
            {
                inventory.AddItem(itemsInCrafting[i].item);
            }
            itemsInCrafting[i].item = null;
            itemsInCrafting[i].amount = 0;
        }

        if (craft && enoughItemsForCraftingBig[i])
        {
            int amount = itemsInCrafting[i].amount;
            for (int counter = 0; counter < amount; counter++)
            {
                inventory.AddItem(itemsInCrafting[i].item);                
            }
        }
        itemsInCrafting[i].item = null;
        itemsInCrafting[i].amount = 0;
        inventory.RefreshInventory();
        RefreshWorkbench();
    }

    
}
