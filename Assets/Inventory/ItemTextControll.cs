using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTextControll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupText;
    public GameObject canvas; 
    public static Boolean visible = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Item itemInSlot = GetComponentInParent<ShowItem>().itemToShow;

        if (!visible)
        {
            visible = true;
            if (itemInSlot != null)
            {
                var tooltip = Instantiate(popupText, new Vector3(transform.position.x, transform.position.y + 2, 0),
                    popupText.transform.rotation);
                tooltip.transform.SetParent(canvas.transform);
                popupText.GetComponentInChildren<Text>().text = itemInSlot.name;
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
 
