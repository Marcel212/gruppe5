using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryInteraction : MonoBehaviour
{

    [SerializeField] private GameObject fpcObject;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private GameObject workbench;
    private bool inventoryOpen;
    private bool craftingOpen;

    private FirstPersonController fpc;
    private BlockInteraction blockInteraction;
    private GameObject crosshair;
    private InventoryControll inventoryControll;
    private WorkbenchControll workbenchControll;

    private Vector3 originalPositionInventory;
    private Vector3 originalPositionWorkbench;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryOpen = false;
        fpc = fpcObject.GetComponent<FirstPersonController>();
        blockInteraction = fpcObject.GetComponent<BlockInteraction>();
        crosshair = GameObject.Find("Crosshair");
        inventoryControll = inventory.GetComponent<InventoryControll>();
        workbenchControll = workbench.GetComponent<WorkbenchControll>();
        craftingOpen = false;
        originalPositionInventory = inventory.transform.position;
        originalPositionWorkbench = workbench.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Das Inventar wird hier auf I geöffnet bzw. geschlossen. 
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.transform.position = originalPositionInventory;
            inventoryOpen = !inventoryOpen;
            inventory.gameObject.SetActive(inventoryOpen);
        }

        // TODO Crafting herausnehmen sobald es in die Workbench integriert ist
        if (Input.GetKeyUp(KeyCode.C))
        {
            workbench.transform.position = originalPositionWorkbench;
            craftingOpen = !craftingOpen;
            workbench.gameObject.SetActive(craftingOpen);
        }
        
        
        // Sorgt für das befreien des Cursors und entfernt das Kreuz in der Mitte falls ein Fenster offen ist. 
        if (inventoryOpen || craftingOpen)
        {
            fpc.m_MouseLook.SetCursorLock(false);
            blockInteraction.enabled = false;
            crosshair.SetActive(false);
            // TODO RotateView ausstellen? 
        }
        else
        {
            fpc.m_MouseLook.SetCursorLock(true);
            blockInteraction.enabled = true;
            toolTip.gameObject.SetActive(false);
            crosshair.SetActive(true);
            inventoryControll.ClearCraftingField(false);
            inventoryControll.RefreshInventory();
            
            workbenchControll.ClearCraftingField(false);
            workbenchControll.RefreshWorkbench();
        }
    }

}
