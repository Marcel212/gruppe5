using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
 
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;
        
        //Script und Item vom Dragged item
        ShowItem itemScriptDrag = eventData.pointerDrag.transform.GetComponent<ShowItem>();
        Item itemDragged = itemScriptDrag.itemToShow;
        
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
           //itemScriptDrag.itemToShow = null;
            Debug.Log("Item wegwerfen");
        }
        else
        {
            //Debug.Log("Herkunft-Name: " + eventData.pointerDrag.transform.GetComponent<ShowItem>().itemToShow.name + " | Ziel-Name: " + eventData.pointerEnter.name);
            
            if (itemDragged != null)
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
                
                
            }
            
            
            
        }
    }
}
