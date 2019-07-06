using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowDragging : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
  
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }


    //TODO eventuell Fenster besser positionieren, damit es nicht spring? 
    public void OnDrag(PointerEventData eventData)
    {
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
}
