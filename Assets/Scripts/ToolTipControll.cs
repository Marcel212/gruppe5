using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolTipControll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupText;
    public GameObject canvas; 
    public static Boolean visible = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Item itemInSlot = GetComponentInParent<ItemSlots>().itemToShow;

        if (!visible)
        {
            if (itemInSlot != null && eventData.dragging == false)
            {
                visible = true;
                popupText.transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
                //tooltip.transform.SetParent(canvas.transform);
                popupText.GetComponentInChildren<Text>().text = itemInSlot.name;
                popupText.SetActive(visible);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (visible)
        {
            visible = false;

        }
    }
}
 
