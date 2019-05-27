﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite itemPicuture;
    public GameObject objectInGame;
}