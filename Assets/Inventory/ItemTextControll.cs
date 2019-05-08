using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTextControll : MonoBehaviour
{
    public Transform popupText;

    public static Boolean visible = false;


    private void OnMouseEnter()
    {
        if (!visible)
        {
            popupText.GetComponent<TextMesh>().text = "Something new";
            visible = true;
            Instantiate(popupText, new Vector3(transform.position.x, transform.position.y + 2, 0), popupText.rotation);
            
        }
    }

    private void OnMouseExit()
    {
        if (visible)
        {
            visible = false;
            
        }
    }
}
 
