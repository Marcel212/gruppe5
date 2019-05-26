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
            Debug.Log("Herkunft-Name: " + eventData.pointerDrag.transform.GetComponent<ShowItem>().itemToShow.name + " | Ziel-Name: " + eventData.pointerEnter.name);

            ShowItem itemScript = eventData.pointerDrag.transform.GetComponent<ShowItem>();
            Item itemDragged = itemScript.itemToShow;
            
            
            GameObject droppedOnObject = eventData.pointerEnter;

            if (itemDragged != null && droppedOnObject.GetComponent<ShowItem>().itemToShow == null)
            {
                droppedOnObject.GetComponent<ShowItem>().itemToShow = itemDragged;
                itemScript.itemToShow = null;
            }
            
            
            
        }
    }
}
