﻿using UnityEngine;

public class HotKeyControll : MonoBehaviour
{
    
    // TODO Auf Tasten 1-0 Reagieren lassen 
    // Start is called before the first frame update

    [SerializeField] private GameObject hotKeyInventory;
    private ItemSlots[] slots;
    private Item itemInInventory;
    private int amount;
    private void Start()
    {
        slots = hotKeyInventory.transform.GetComponentsInChildren<ItemSlots>();
    }

    


}


