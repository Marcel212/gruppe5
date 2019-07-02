using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfRecipesScript : MonoBehaviour
{
    private List<CraftingRecipe> smallRecipes;
    private RecipeSlots[] recipeSlot;
    [SerializeField] private ScriptableManagerScript manager;
    public Slider mainSlider;
    // Start is called before the first frame update
    private void OnValidate()
    {
        recipeSlot = GetComponentsInChildren<RecipeSlots>();
        smallRecipes = manager.GetAllSmallRecipes();
    }

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { FillPageByNumber(); });
    }

    public void FillPageByNumber()
    {
        
        int index = 0;
        for (index = 0;index< recipeSlot.Length; index++)
        {
            recipeSlot[index].CraftingRecipe = null;
        }
        
        index = 0;
        int firstIndexInBook = (int)mainSlider.value * 20;
        for (int indexInBook = firstIndexInBook; indexInBook< smallRecipes.Capacity && indexInBook< firstIndexInBook+20 ; indexInBook++)
        {
          
            recipeSlot[index].CraftingRecipe = smallRecipes[indexInBook];
            index++;
        }
    }



    public void OpenBook(GameObject book)
    {
        book.SetActive(!book.activeSelf);
    }
}
