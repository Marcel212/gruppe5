using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookOfRecipesScript : MonoBehaviour
{
    private List<CraftingRecipe> smallRecipes;
    private ItemSlots[] itemSlots;
    [SerializeField] private ScriptableManagerScript manager;
    public Slider mainSlider;
    // Start is called before the first frame update
    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<ItemSlots>();
        smallRecipes = manager.GetAllSmallRecipes();
    }

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { FillPageByNumber(); });
    }

    public void FillPageByNumber()
    {
        //int indexInBook = (int)mainSlider.value * 20;
        //Debug.Log("IndexInBook: " + indexInBook);
        int index = 0;
        for (index = 0;index< itemSlots.Length; index++)
        {
            itemSlots[index].Item = null;
            itemSlots[index].Amount = 0;
        }

        /*for (int index = 0; index < itemSlots.Length; index++)
        {
            
            if (indexInBook < smallRecipes.Capacity)
            {
                Debug.Log("Index von Slots: " + index); Debug.Log("Recipes Länge: " + smallRecipes.Capacity);
                itemSlots[index].Item = smallRecipes[indexInBook].GetResult().item;
                itemSlots[index].Amount = smallRecipes[indexInBook].GetResult().amount;
            }
            else
            {
                if (index != 0)
                {
                    index--;
                }
            }
            indexInBook++;
        }*/
        index = 0;
        int firstIndexInBook = (int)mainSlider.value * 20;
        for (int indexInBook = firstIndexInBook; indexInBook< smallRecipes.Capacity && indexInBook< firstIndexInBook+20 ; indexInBook++)
        {
            Debug.Log("Index von Slots: " + index); Debug.Log("Recipes Länge: " + smallRecipes.Capacity);
            itemSlots[index].Item = smallRecipes[indexInBook].GetResult().item;
            itemSlots[index].Amount = smallRecipes[indexInBook].GetResult().amount;
            index++;
        }
    }



    public void OpenBook(GameObject book)
    {
        book.SetActive(!book.activeSelf);
    }
}
