using TMPro;
using UnityEngine;

public class HotKeyControll : MonoBehaviour
{
    
    // TODO Auf Tasten 1-0 Reagieren lassen 
    // TODO Performanter schreiben 
    // Start is called before the first frame update

    [SerializeField] private GameObject hotKeyInventory;
    void Update()
    {
        RefreshHotKeys();
        
    }

    public void RefreshHotKeys()
    {
        for (int i = 0; i < 10; i++)
        {
            // Verknüpfe jeden Hotkey unten mit dem Hotkey aus dem Inventar 
            ItemSlots slot = hotKeyInventory.transform.GetChild(i).GetComponent<ItemSlots>();
            Item itemInInventory = slot.itemToShow;
            int amount = slot.amount;
            
            
            Transform childWithItem =  transform.GetChild(i);
            childWithItem.GetComponent<ItemSlots>().itemToShow = itemInInventory;
            childWithItem.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = amount.ToString();
        }
        
    }
}


