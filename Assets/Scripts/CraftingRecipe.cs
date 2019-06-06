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
   
 }




[CreateAssetMenu(fileName= "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAndAmount> materials;
    public ItemAndAmount result;
}
