using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 oldPosition;

    private void Start()
    {
        oldPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Item itemInSlot = GetComponentInParent<ShowItem>().itemToShow;
        if (itemInSlot != null)
        {
            transform.position = Input.mousePosition;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = oldPosition;
    }
}
