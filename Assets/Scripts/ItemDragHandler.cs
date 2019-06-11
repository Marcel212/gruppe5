using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 m_oldPosition;
    private CanvasGroup m_canvasGroup;
    private ItemSlots m_itemScript;

    private void Start()
    {
        m_canvasGroup = GetComponentInParent<CanvasGroup>();
        m_itemScript = GetComponentInParent<ItemSlots>();
        m_oldPosition = m_itemScript._currentImage.transform.localPosition;


    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = false;
    }


    public void OnDrag(PointerEventData eventData)
    {
    
        if (m_itemScript.itemToShow != null)
        {
            //m_itemScript._currentImage.transform.position = Input.mousePosition;
            transform.position = Input.mousePosition;
        }
    
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //m_itemScript._currentImage.transform.localPosition = m_oldPosition;

        transform.localPosition = m_oldPosition;
    
        m_canvasGroup.blocksRaycasts = true;
    }

}
    