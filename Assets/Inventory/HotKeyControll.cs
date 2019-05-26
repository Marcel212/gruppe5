using UnityEngine;

public class HotKeyControll : MonoBehaviour
{
    
    // TODO Mit HotKeyPanel im Inventar verknüpfen
    // TODO Auf Tasten 1-0 Reagieren lassen 
    // Start is called before the first frame update

    [SerializeField] private GameObject hotKeyInventory;
    void Start()
    {
        RefreshHotKeys();
        
    }

    public void RefreshHotKeys()
    {
        for (int i = 0; i < 10; i++)
        {
            // Verknüpfe jeden Hotkey unten mit dem Hotkey aus dem Inventar 
            Item itemInInventory = hotKeyInventory.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<ShowItem>().itemToShow;
            
            Transform childWithItem =  transform.GetChild(i).GetChild(0).GetChild(0);
            childWithItem.GetComponent<ShowItem>().itemToShow = itemInInventory;
        }
        
    }
}


