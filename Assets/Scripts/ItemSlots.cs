using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{

    public Item itemToShow;
    public int amount;
    
    private Image _currentImage;
    private TextMeshProUGUI _textAmount;
    private Transform _transformCache;

    private void Start()
    {

        _transformCache = transform.GetChild(0).GetChild(0);
        _currentImage = _transformCache.GetComponent<Image>();
        _textAmount = _transformCache.GetChild(0).GetComponent<TextMeshProUGUI>();
        Debug.Log(_textAmount.text);
    }

    // Start is called before the first frame update
    void Update()
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
            _textAmount.gameObject.SetActive(false);
        }
        
        
        
    }
}
