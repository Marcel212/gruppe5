using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfRecipesScript : MonoBehaviour
{
    private List<CraftingRecipe> recipes;
    private ItemSlots[] itemSlots;
    [SerializeField] private ScriptableManagerScript manager;
    public Slider mainSlider;
    // Start is called before the first frame update
    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlots>();
        recipes = manager.GetAllRecipes();
    }

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { FillPageByNumber(); });
    }

    public void FillPageByNumber()
    {
        int indexInBook = (int)mainSlider.value * 20;
        Debug.Log("IndexInBook: " + indexInBook);

        for(int index = 0;index< itemSlots.Length; index++)
        {
            itemSlots[index].Item = null;
            itemSlots[index].Amount = 0;
        }

        for (int index = 0; index < itemSlots.Length; index++)
        {
            
            if (indexInBook < recipes.Capacity)
            {
                Debug.Log("Index von Slots: " + index); Debug.Log("Recipes Länge: " + recipes.Capacity);
                itemSlots[index].Item = recipes[indexInBook].GetResult().item;
                itemSlots[index].Amount = recipes[indexInBook].GetResult().amount;
            }
          

            indexInBook++;
        }
    }
}
