using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
 
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Item wegwerfen");
        }
        else
        {
            //Debug.Log("Herkunft-Name: " + eventData.pointerDrag.transform.GetComponent<ShowItem>().itemToShow.name + " | Ziel-Name: " + eventData.pointerEnter.name);

            ShowItem itemScriptDrag = eventData.pointerDrag.transform.GetComponent<ShowItem>();
            Item itemDragged = itemScriptDrag.itemToShow;
            
            
            GameObject droppedOnObject = eventData.pointerEnter;

            if (itemDragged != null)
            {
                ShowItem itemScriptDropped = droppedOnObject.GetComponent<ShowItem>();
                Item itemOnDropped = itemScriptDropped.itemToShow;
                
                
                itemScriptDropped.itemToShow = itemDragged;
                itemScriptDrag.itemToShow = itemOnDropped;
            }
            
            
            
        }
    }
}
