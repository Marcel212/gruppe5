using UnityEngine;

public class OnClickRecipe : MonoBehaviour
{
    [SerializeField] private Transform craftingBox;
    [SerializeField] private InventoryControll inventory;
    [SerializeField] private WorkbenchControll workbench;
    
    private ItemSlots[] craftingSlots;
    private int lengthOfCraftingField;
    
    private void OnValidate()
    {
        craftingSlots = craftingBox.GetComponentsInChildren<ItemSlots>();
        lengthOfCraftingField = craftingSlots.Length;
    }
    
    public void Fill()
    {
        //Alle vorherigen Items müssen aus dem CraftingField herausgenommen werden.
        inventory.ClearCraftingField(false);
        workbench.ClearCraftingField(false);
        
        // Sucht das richtige Rezept heraus
        RecipeSlots recipeSlot =  GetComponentInParent<RecipeSlots>();
        if (recipeSlot.recipeToShow == null)
        {
            return;
        }
        CraftingRecipe recipe = Instantiate( recipeSlot.recipeToShow);

        // Anlegen von Arbeitsvariablen
        ItemAndAmount[] toFill = new ItemAndAmount[lengthOfCraftingField];
        var tempArray = new bool[lengthOfCraftingField];
        var resultBool = true;

        for (int index = 0; index < recipe.Materials.Length; index++)
        {
            //Überprüfung ob Materialien vorhanden sind und für Einfärbung sorgen durch true oder false
            if (recipe.Materials[index].item == null || inventory.RemoveItemInInventory(recipe.Materials[index].item))
            {
                tempArray[index] = true;
            }
            else
            {
                tempArray[index] = false;
                resultBool = false;
            }

            
            toFill[index] = recipe.Materials[index]; 
        }
        
        //Ergebnis zum Array hinzufügen
        toFill[toFill.Length - 1] = recipe.Result;
        tempArray[tempArray.Length - 1] = resultBool;
        
        var testArray = (ItemAndAmount[]) toFill.Clone() ;
       
        //Arbeitsvariablen übertragen an die jeweiligen CraftingFelder und ins UI
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
