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
    private void Start()
    {
        Debug.Log(inventory.ItemsInCrafting.Length);

    }

    public void Fill()
    {
        // TODO Prüfe ob Items Im Inventar sind -> Verschiebe sie. Sonst ausgrauen? 
        RecipeSlots recipeSlot =  GetComponentInParent<RecipeSlots>();
        CraftingRecipe recipe = recipeSlot.recipeToShow;
        
        ItemAndAmount[] toFill = new ItemAndAmount[LengthOfCraftingField];
        var tempArray = new bool[LengthOfCraftingField];

        for (int index = 0; index < recipe.materials.Length; index++)
        {
            List<ItemAndAmount> ItemsFound;
            List<int> IndicesFound;


            //Überprüfung
            if (inventory.InventoryContainsItem(recipe.materials[index].item, out ItemsFound, out IndicesFound) && ItemsFound[0].amount >=recipe.materials[index].amount)
            {
                // Menge abziehen
                tempArray[index] = true;
            }
            else
            {
                tempArray[index] = false;

            }

           
            toFill[index] = recipe.materials[index]; 
        }
        
        toFill[toFill.Length - 1] = recipe.GetResult();
        tempArray[tempArray.Length - 1] = true;
        
        inventory.ItemsInCrafting = toFill;
        inventory.EnoughItemsForCrafting = tempArray;
        Debug.Log(inventory.ItemsInCrafting.Length);
    }
}
