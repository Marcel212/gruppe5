using System;
using TMPro;
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
        Item itemInSlot;
        ItemSlots itemSlot = GetComponentInParent<ItemSlots>();
        RecipeSlots recipeSlot = GetComponentInParent<RecipeSlots>();

        if(itemSlot != null)
        {
            itemInSlot = itemSlot.itemToShow;

        }
        else
        {
            itemInSlot = recipeSlot.ResultAsItem;
        }

        if (!visible)
        {
            if (itemInSlot != null && eventData.dragging == false)
            {
                visible = true;
                popupText.transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
                //tooltip.transform.SetParent(canvas.transform);
                popupText.GetComponentInChildren<TextMeshProUGUI>().text = itemInSlot.name;
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
 
