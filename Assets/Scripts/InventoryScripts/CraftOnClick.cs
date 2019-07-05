using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftOnClick : MonoBehaviour
{
    [SerializeField] private InventoryControll inventory;
    [SerializeField] private WorkbenchControll workbench;
   
    //Craftet, falls ein mögliches Rezept sich in dem Crafting Feld befindet. 
    public void CraftIt()
    {
            inventory.ClearCraftingField(true);
            workbench.ClearCraftingField(true);
    }
}
