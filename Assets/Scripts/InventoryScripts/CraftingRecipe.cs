using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ItemAndAmount
 {
     public Item item;
     [Range(0,64)]
     public int amount;

    public int indexInList;
 }




[CreateAssetMenu(fileName= "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{

    public CraftingField size;
    [SerializeField]
    private ItemAndAmount[] materials;
    [SerializeField] private ItemAndAmount result;

    public ItemAndAmount[] Materials
    {
        get {
            return materials;
        }
    }

    public ItemAndAmount Result
    {
        get { return result; }
    }

    
}

public enum CraftingField
{
    Small,
    Big
};