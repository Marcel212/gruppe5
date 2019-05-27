using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Placement m_placement;

    private HotKeyControll m_hotkeyScript;

    private void Start()
    {
        m_hotkeyScript = GameObject.FindGameObjectWithTag("HotKeys").GetComponent<HotKeyControll>();
    }

    public void OnDrop(PointerEventData eventData)
    {        
        //Script und Item vom Dragged item
        ItemSlots itemScriptDrag = eventData.pointerDrag.transform.parent.parent.GetComponent<ItemSlots>();
        Item itemDragged = itemScriptDrag.itemToShow;
        
        Debug.Log("Befindet sich im Placement : " + m_placement) ;
        if (itemDragged != null)
        {
            if (m_placement == Placement.World)
            {
                itemScriptDrag.itemToShow = null;
                m_hotkeyScript.RefreshHotKeys();
                
                // TODO Gameobject erzeugen
                Debug.Log("Wegwerfen");
            }
            else if(m_placement == Placement.Inventory || m_placement == Placement.Hotkeys)
            {
                //Script und Item vom Dropped item
                ItemSlots itemScriptDropped = eventData.pointerEnter.transform.parent.parent.GetComponent<ItemSlots>();
    
                //Wenn ein Script existiert. 
                if (itemScriptDropped != null)
                {    
                    Item itemOnDropped = itemScriptDropped.itemToShow;
    
                    //Items tauschen
                    itemScriptDropped.itemToShow = itemDragged;
                    itemScriptDrag.itemToShow = itemOnDropped;
                }
            
                // performanter refreshen?
                m_hotkeyScript.RefreshHotKeys();
                
                
                Debug.Log("Refresh");
                
            }else if (m_placement == Placement.Forbidden)
            {
                Debug.Log("Verboten");
            }
        }
    }
    
    public enum Placement {Hotkeys, Forbidden, Inventory, World};

}
