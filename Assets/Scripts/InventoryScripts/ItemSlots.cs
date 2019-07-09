using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{

    public Item itemToShow;

    [SerializeField] public Image _currentImage;
    [SerializeField] private TextMeshProUGUI _textAmount;
    
    public int amount;
    public DropZone.Placement placement;
    public int indexInPlacement;
    
    
    
    public Item Item
    {
        get { return itemToShow; }
        set
        {
            itemToShow = value;
            if (itemToShow != null)
            {
                _currentImage.sprite = itemToShow.itemPicuture;
            }
            else
            {
                _currentImage.sprite = null;
                amount = 0;
            }
        }
    }
 

    public int Amount
    {
        get { return amount; }
        set
        {
            amount = value;
            if (amount != 0)
            {
                _textAmount.gameObject.SetActive(true);
                _textAmount.text = amount.ToString();
            }
            else
            {
                _textAmount.gameObject.SetActive(false);
                Item = null;
            }
        }
    }

     /*
      * Hier werden den Attributen von Mengenangabe und Bild die jeweiligen Komponenten zugewiesen.
      * Außerdem werden Nutzereingaben aus dem Editor überprüft und ein Default Zustand hergestellt.
      */
    private void OnValidate()
    {
        if (_currentImage == null)
        {
            _currentImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        if (_textAmount == null)
        {
            _textAmount = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        }
        
        _textAmount.gameObject.SetActive(false);
        Item = itemToShow;
        Amount = amount;
    }


}
