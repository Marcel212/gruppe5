using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{

    public Item itemToShow;
    private Image currentImage;
    // Start is called before the first frame update
    void Update()
    {
        //Anzeigen des Bildes von dem richtigen Item 
        currentImage = GetComponentInParent<Image>();

        if(itemToShow != null)
        { 
            currentImage.sprite = itemToShow.itemPicuture;
            //transform.GetComponent<Image>().enabled = true;
        }
        else
        {
            currentImage.sprite = null;
        }
        
        
        
    }

    private void OnMouseOver()
    {
        
    }
}
