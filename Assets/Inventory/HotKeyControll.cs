using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotKeyControll : MonoBehaviour
{
    
    // TODO Mit HotKeyPanel im Inventar verknüpfen
    // TODO Auf Tasten 1-0 Reagieren lassen 
    // Start is called before the first frame update

    [SerializeField] private GameObject hotKeyInventory;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            // Verknüpfe jeden Hotkey unten mit dem Hotkey aus dem Inventar 
            Item itemInInventory = hotKeyInventory.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<ShowItem>().itemToShow;
            
            //Wenn ein Item im Slot ist
            if (itemInInventory != null)
            {
                AddToHotKey(i, itemInInventory);
            }
        }
    }

    /*
     * Wird aufgerufen, wenn im Inventar etwas zum HotKey hinzugefügt wird.
     */
    public void AddToHotKey(int index, Item itemToAdd)
    {
        Transform childWithItem =  transform.GetChild(index).GetChild(0).GetChild(0);
        childWithItem.GetComponent<ShowItem>().itemToShow = itemToAdd;
        //childWithItem.GetComponent<Image>().enabled = true;

    }
}
