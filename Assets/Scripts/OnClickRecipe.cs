using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickRecipe : MonoBehaviour
{
    [SerializeField] private Transform craftingBox;
    [SerializeField] private InventoryControll inventory;
    [SerializeField] private ScriptableManagerScript manager;
    public ItemSlots[] craftingSlots;
    private ItemAndAmount[] listForCraftingmaterial;

    private int LengthOfCraftingField = 5;
    private void OnValidate()
    {
        //craftingSlots = craftingBox.GetComponentsInChildren<ItemSlots>();
        //listForCraftingmaterial = inventory.ItemsInCrafting;
    }
    
    public void Fill()
    {
        inventory.ClearCraftingField();
        // TODO Prüfe ob Items Im Inventar sind -> Verschiebe sie. Sonst ausgrauen? 
        RecipeSlots recipeSlot =  GetComponentInParent<RecipeSlots>();
        CraftingRecipe recipe =Instantiate( recipeSlot.recipeToShow);
        
        ItemAndAmount[] toFill = new ItemAndAmount[LengthOfCraftingField];
        var tempArray = new bool[LengthOfCraftingField];
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
       
        inventory.ItemsInCrafting = testArray;

        Debug.Log(testArray.GetHashCode() + "  " + inventory.ItemsInCrafting.GetHashCode());
        inventory.EnoughItemsForCrafting = tempArray;
       
    }
}
