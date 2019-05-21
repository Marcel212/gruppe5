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
            ShowItem itemScript = eventData.pointerDrag.transform.GetComponent<ShowItem>();
            Item itemDragged = itemScript.itemToShow;
            
            
            GameObject droppedOnObject = eventData.pointerEnter;
            

            droppedOnObject.GetComponent<ShowItem>().itemToShow = itemDragged;
            itemScript.itemToShow = null;
            
            
            Debug.Log("Herkunft-Name: " + eventData.pointerDrag.transform.GetComponent<ShowItem>().itemToShow.name + " | Ziel-Name: " + eventData.pointerEnter.name);
        }
    }
}
