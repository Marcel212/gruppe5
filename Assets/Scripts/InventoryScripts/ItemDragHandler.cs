using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 oldPosition;
    private CanvasGroup canvasGroup;
    private ItemSlots itemScript;

    private void Start()
    {
        canvasGroup = GetComponentInParent<CanvasGroup>();
        itemScript = GetComponentInParent<ItemSlots>();
        oldPosition = itemScript._currentImage.transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (itemScript.itemToShow != null)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = oldPosition;
        canvasGroup.blocksRaycasts = true;
    }

}
    