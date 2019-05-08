using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{

    public Item displayItem;
    // Start is called before the first frame update
    void Start()
    {
        Image currentImage = GetComponentInParent<Image>();
        currentImage.sprite = displayItem.itemPicuture;
        
        
        
    }

    private void OnMouseOver()
    {
        
    }
}
