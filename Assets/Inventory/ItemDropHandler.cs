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
            Debug.Log("Herkunft-Name: " + eventData.pointerDrag.name + " | Ziel-Name: " + eventData.pointerEnter.name);
        }
    }
}
