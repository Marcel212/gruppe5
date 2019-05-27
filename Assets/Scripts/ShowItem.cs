using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{

    public Item itemToShow;
    public int amount;
    
    private Image currentImage;
    private TextMeshProUGUI textAmount;

    private void Start()
    {
        currentImage = GetComponent<Image>();
        textAmount = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Debug.Log(textAmount.text);
    }

    // Start is called before the first frame update
    void Update()
    {
        if(itemToShow != null)
        { 
            currentImage.sprite = itemToShow.itemPicuture;
            textAmount.gameObject.SetActive(true);
            textAmount.text = amount.ToString();
        }
        else
        {
            currentImage.sprite = null;
            textAmount.gameObject.SetActive(false);
        }
        
        
        
    }

}
