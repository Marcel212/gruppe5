using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{

    public Item itemToShow;

    [SerializeField] private Image _currentImage;
    [SerializeField] private TextMeshProUGUI _textAmount;
    
    public int amount;
    
    
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


    private void Start()
    {
        if (_currentImage == null)
        {
            _currentImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        if (_textAmount == null)
        {
            _textAmount = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        }
        //Auf Default setzen & alle Eingaben vom Editor prüfen 
        Item = itemToShow;
        Amount = amount;
        _textAmount.gameObject.SetActive(false);


    }

    public void RefreshSlotData()
    {
        if(itemToShow != null)
        { 
            _currentImage.sprite = itemToShow.itemPicuture;
            _textAmount.gameObject.SetActive(true);
            _textAmount.text = amount.ToString();
        }
        else
        {
            _currentImage.sprite = null;
        }
    }

    // TODO soll aktualisiert werden, sobald Inventar offen bzw. etwas eingesammelt wird. 
    private void Update()
    {
        RefreshSlotData();
    }
}
