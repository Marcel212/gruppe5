using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 m_oldPosition;
    private CanvasGroup m_canvasGroup;
    private void Start()
    {
        m_oldPosition = transform.localPosition;
        m_canvasGroup = this.transform.parent.GetComponentInParent<CanvasGroup>();
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        
        
        m_canvasGroup.blocksRaycasts = false;
    }
    
    
    public void OnDrag(PointerEventData eventData)
    {
        Item itemInSlot = GetComponentInParent<ShowItem>().itemToShow;
        if (itemInSlot != null)
        {
            transform.position = Input.mousePosition;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.localPosition = m_oldPosition;
        
        m_canvasGroup.blocksRaycasts = true;
    }

}
