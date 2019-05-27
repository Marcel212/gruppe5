using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 m_oldPosition;
    private CanvasGroup m_canvasGroup;
    private ItemSlots m_itemScript;
    public DropZone.Placement m_placement;
    
    private void Start()
    {
        m_oldPosition = transform.localPosition;
        m_canvasGroup = this.transform.parent.GetComponentInParent<CanvasGroup>();
        m_itemScript = GetComponentInParent<ItemSlots>();
    }

    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        m_canvasGroup.blocksRaycasts = false;
    }
    
    
    public void OnDrag(PointerEventData eventData)
    {
        
        if (m_itemScript.itemToShow != null)
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
