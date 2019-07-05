using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickRecipe : MonoBehaviour
{
    [SerializeField] private Transform craftingBox;
    [SerializeField] private InventoryControll inventory;
    [SerializeField] private WorkbenchControll workbench;
    public ItemSlots[] craftingSlots;
  

    private int lengthOfCraftingField;
    private void OnValidate()
    {
        craftingSlots = craftingBox.GetComponentsInChildren<ItemSlots>();
        lengthOfCraftingField = craftingSlots.Length;
    }
    
    public void Fill()
    {
        inventory.ClearCraftingField(false);
        workbench.ClearCraftingField(false);
        RecipeSlots recipeSlot =  GetComponentInParent<RecipeSlots>();
        if (recipeSlot.recipeToShow == null)
        {
            return;
        }
        CraftingRecipe recipe = Instantiate( recipeSlot.recipeToShow);

        
        ItemAndAmount[] toFill = new ItemAndAmount[lengthOfCraftingField];
        var tempArray = new bool[lengthOfCraftingField];
        var resultBool = true;

        for (int index = 0; index < recipe.Materials.Length; index++)
        {
            List<ItemAndAmount> ItemsFound;
            List<int> IndicesFound;


            //Überprüfung
            if (recipe.Materials[index].item == null || inventory.RemoveItemInInventory(recipe.Materials[index].item))
            {
                tempArray[index] = true;
            }
            else
            {
                Debug.Log("Element not exist");
                tempArray[index] = false;
                resultBool = false;
            }

           
            toFill[index] = recipe.Materials[index]; 
        }
        
        toFill[toFill.Length - 1] = recipe.Result;
        tempArray[tempArray.Length - 1] = resultBool;
        var testArray = (ItemAndAmount[]) toFill.Clone() ;
       
       

      
        if (lengthOfCraftingField == 5)
        {
            inventory.EnoughItemsForCraftingSmall = tempArray;
            inventory.ItemsInCrafting = testArray;
        }
        else
        {
            workbench.EnoughItemsForCraftingBig = tempArray;
            workbench.ItemsInCrafting = testArray;
        }
        
    }
}
