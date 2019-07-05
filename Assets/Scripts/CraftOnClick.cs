using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftOnClick : MonoBehaviour
{
    [SerializeField] private InventoryControll inventory;

    [SerializeField] private WorkbenchControll workbench;
    // Update is called once per frame
    public void CraftIt()
    {
        
            inventory.ClearCraftingField(true);
            workbench.ClearCraftingField(true);

    }
}
