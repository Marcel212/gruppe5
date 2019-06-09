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
        //m_oldPosition = transform.localPosition;
        m_canvasGroup = GetComponentInParent<CanvasGroup>();
        m_itemScript = GetComponentInParent<ItemSlots>();
        Debug.Log("Canvas Group " + m_canvasGroup);
        Debug.Log("ItemScript " + m_itemScript);
        Debug.Log("Image " + m_itemScript._currentImage);
        // TODO Warum wirft es bei einem Script ein Error? 
        m_oldPosition = m_itemScript._currentImage.transform.localPosition;
        Debug.Log("Position " + m_oldPosition);


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
            m_itemScript._currentImage.transform.position = Input.mousePosition;
            //transform.position = Input.mousePosition;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        m_itemScript._currentImage.transform.localPosition = m_oldPosition;

        //transform.localPosition = m_oldPosition;
        
        m_canvasGroup.blocksRaycasts = true;
    }

}
