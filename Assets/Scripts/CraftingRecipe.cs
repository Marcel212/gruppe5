using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class ItemAndAmount : IComparer
 {
     public Item item;
     [Range(0,64)]
     public int amount;

     public int indexInList;


   
     public int CompareTo(object obj)
     {
         ItemAndAmount newObject = obj as ItemAndAmount;
         return String.Compare(item.name, newObject.item.name, StringComparison.Ordinal);
     }

     public int Compare(object x, object y)
     {
         ItemAndAmount firstObject = x as ItemAndAmount;
         ItemAndAmount secondObject = y as ItemAndAmount;

         return String.CompareOrdinal(firstObject.item.name, secondObject.item.name);
     }
 }




[CreateAssetMenu(fileName= "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{

    public CraftingField size;
    public ItemAndAmount[] materials;
    public ItemAndAmount result;

    public ItemAndAmount GetResult()
    {
        return result;
    }

    
}

public enum CraftingField
{
    Small,
    Big
};