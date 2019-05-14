using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemTextControll : MonoBehaviour
{
    public GameObject popupText;

    public static Boolean visible = false;

    public void enterGameObject()
    {
        Item itemInSlot = GetComponentInParent<ShowItem>().itemToShow;

        Debug.Log("MouseEnter with " + visible);
        Debug.Log("Object = " + gameObject.name);
        if (!visible)
        {
            

            popupText.GetComponentInChildren<Text>().text = itemInSlot.name;
            visible = true;
            var tooltip = Instantiate(popupText, new Vector3(transform.position.x, transform.position.y + 2, 0),
                popupText.transform.rotation);
            tooltip.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
            //            popupText.SetActive(visible);

        }
    }

    public void exitGameObject()
    {
       
        

            Debug.Log("MouseExit with " + visible);
            Debug.Log("Object = " + gameObject.name);
            if (visible)
            {
                visible = false;

            }
        
    }
}
 
