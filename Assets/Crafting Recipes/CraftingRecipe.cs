using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAndAmout
{
    public Item item;
    [Range(0,64)]
    public int amout;
}
[CreateAssetMenu(fileName= "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAndAmout> materials;
    public ItemAndAmout result;
}
