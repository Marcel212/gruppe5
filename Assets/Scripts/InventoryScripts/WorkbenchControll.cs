using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControll : MonoBehaviour
{
    [SerializeField] private InventoryControll inventory;

    [SerializeField] private ItemAndAmount[] itemsInCrafting;
    private ItemSlots[] itemSlotsCrafting;

    private bool[] enoughItemsForCraftingBig= new bool[10];


    //Zuweisung von CraftingSlots an das Script
    private void OnValidate()
    {
        itemSlotsCrafting = GetComponentsInChildren<ItemSlots>();
        EnoughItemsForCraftingBig = enoughItemsForCraftingBig;
        RefreshWorkbench();

    }

    //Lasst es zu, das es bei Awake gefunden wird, aber nicht beim Start des Spiels sichtbar ist. 
    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Färbt die CraftingFelder nach den Angaben im Array neu ein. 
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
    
    // Weißt den CraftingSlots neue Werte zu. 
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

    // Passe alle UI Elemente an die Liste der InventarElemente an
    public void RefreshWorkbench()
    {
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
    
    
    //Leert das CraftingFeld, bei craft ist True, wird nur das Ergebnis ins Inventar hinzgefügt
    // Bei False werden die Materialien hinzugefügt. 
    public void ClearCraftingField(bool craft)
    {
        int i = 0;
        for ( i = 0; i < itemsInCrafting.Length-1; i++)
        {
            if (!craft && enoughItemsForCraftingBig[i])
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
