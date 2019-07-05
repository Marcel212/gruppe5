using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Placement ownPlacement;

    private InventoryControll inventoryControllScript;

    //Findet das InventoryScript bevor das Spiel startet
    private void Awake()
    {
        inventoryControllScript = GameObject.FindWithTag("Inventory").GetComponent<InventoryControll>();
    }


    public void OnDrop(PointerEventData eventData)
    {

        if(eventData.pointerDrag.transform.GetComponentInParent<ItemSlots>() == null)
        {
            return;
        }
        //Finde Placement im Inventory heraus vom Drag (Placement und Index)
        ItemSlots itemScriptDragged = eventData.pointerDrag.transform.GetComponentInParent<ItemSlots>();
        Placement placementDragged = itemScriptDragged.placement;
        int indexDragged = itemScriptDragged.indexInPlacement;
        bool containsItemDragged = itemScriptDragged.itemToShow != null;

        
        // Verändere die Daten in der Datenstruktur Inventory
        // Wenn ein Item sich im Drag befindet
        if (containsItemDragged)
        {
            if (ownPlacement == Placement.World)
            {
                //Platz von DraggedItem Löschen
                inventoryControllScript.RemoveItemPack(indexDragged, placementDragged);
                inventoryControllScript.RefreshInventory();
            }else if (ownPlacement == Placement.Inventory || ownPlacement == Placement.Hotkeys)
            {
                //Finde Placement im Inventory heraus von Drop (Placement und Index)
                ItemSlots itemScriptDropped = eventData.pointerEnter.transform.GetComponentInParent<ItemSlots>();
                Placement placementDropped = itemScriptDropped.placement;
                int indexDropped = itemScriptDropped.indexInPlacement;
                
                //Items tauschen im Inventoryscript 
                inventoryControllScript.SwapItems(indexDragged, placementDragged, indexDropped, placementDropped);

                
            }
            
        }



    }
    
    
    public enum Placement {Hotkeys, Forbidden, Inventory, World, Crafting};

}
