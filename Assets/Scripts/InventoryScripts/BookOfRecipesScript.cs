using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfRecipesScript : MonoBehaviour
{
    private List<CraftingRecipe> recipes;
    private RecipeSlots[] recipeSlot;
    [SerializeField] private ScriptableManagerScript manager;
    public Slider mainSlider;

    public CraftingField size;
    // Start is called before the first frame update
    private void OnValidate()
    {
        recipeSlot = GetComponentsInChildren<RecipeSlots>();
        if (size == CraftingField.Small)
        {
            recipes = manager.GetAllSmallRecipes();
        }
        else
        {
            recipes = manager.GetAllBigRecipes();
        }
       
    }

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { FillPageByNumber(); });
        mainSlider.value = 0;
    }

    public void FillPageByNumber()
    {
        
        int index = 0;
        for (index = 0;index< recipeSlot.Length; index++)
        {
            recipeSlot[index].CraftingRecipe = null;
        }
        
        index = 0;
        int firstIndexInBook = (int)mainSlider.value * 15;
        Debug.Log(firstIndexInBook);
        for (int indexInBook = firstIndexInBook; indexInBook< recipes.Capacity && indexInBook< firstIndexInBook+15 ; indexInBook++)
        {
            Debug.Log("Index: " + indexInBook);
            recipeSlot[index].CraftingRecipe = recipes[indexInBook];
            index++;
        }
    }



    public void OpenBook(GameObject book)
    {
        book.SetActive(!book.activeSelf);
    }
}
