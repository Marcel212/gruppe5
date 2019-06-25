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
        
        RecipeSlots recipeSlot =  GetComponentInParent<RecipeSlots>();
        CraftingRecipe recipe = recipeSlot.recipeToShow;
        
        ItemAndAmount[] toFill = new ItemAndAmount[5];
        

        for (int index = 0; index < recipe.materials.Length; index++)
        {
            toFill[index] = recipe.materials[index]; 
        }
        
        toFill[toFill.Length - 1] = recipe.GetResult();
        
        inventory.ItemsInCrafting = toFill;
        Debug.Log(inventory.ItemsInCrafting.Length);
    }
}
