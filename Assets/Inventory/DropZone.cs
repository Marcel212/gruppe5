using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Placement m_placement;
     
    
    
    
    
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;
        
        //Script und Item vom Dragged item
        ShowItem itemScriptDrag = eventData.pointerDrag.transform.GetComponent<ShowItem>();
        Item itemDragged = itemScriptDrag.itemToShow;
        
        Debug.Log("Befindet sich im Placement : " + m_placement) ;
        if (itemDragged != null)
        {
            if (m_placement == Placement.World)
            {
                itemScriptDrag.itemToShow = null;
                // TODO Gameobject erzeugen
                Debug.Log("Wegwerfen");
            }
            else if(m_placement == Placement.Inventory || m_placement == Placement.Hotkeys)
            {
                //Script und Item vom Dropped item
                ShowItem itemScriptDropped = eventData.pointerEnter.GetComponent<ShowItem>();
    
                //Wenn ein Script existiert. 
                if (itemScriptDropped != null)
                {
                    Item itemOnDropped = itemScriptDropped.itemToShow;
    
                    //Items tauschen
                    itemScriptDropped.itemToShow = itemDragged;
                    itemScriptDrag.itemToShow = itemOnDropped;
                }

                if (m_placement == Placement.Hotkeys)
                {
                    Debug.Log("HotKey Aktualisieren");
                }

            }else if (m_placement == Placement.Forbidden)
            {
                Debug.Log("Verboten");
            }
        }
    }
    
    public enum Placement {Hotkeys, Forbidden, Inventory, World};

}
