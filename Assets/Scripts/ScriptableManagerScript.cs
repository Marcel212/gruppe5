using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptableManagerScript : MonoBehaviour
{
    [SerializeField] private List<Item> itemList;
    [SerializeField] private List<CraftingRecipe> recipeList;
    public Dictionary<string, Item> _dictionary;

    private void Start()
    {
        // create own dictionary for lookups for each name. 
        _dictionary = new Dictionary<string, Item>();
        foreach (var item in itemList)
        {
            _dictionary.Add(item.name, item);
        }

    }

    public Item GetItemByName(string pName)
    {
        Item itemFound = null;
        _dictionary.TryGetValue(pName, out itemFound);
        return itemFound;
    }

    public List<CraftingRecipe> GetAllRecipes()
    {
        return recipeList;
    }
}

