using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryInteraction : MonoBehaviour
{

    [SerializeField] private GameObject fpcObject;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private GameObject workbench;
    [SerializeField] private GameObject box;
    
    private bool inventoryOpen;
    private bool craftingOpen;
    private bool boxOpen;

    private FirstPersonController fpc;
    private BlockInteraction blockInteraction;
    private GameObject crosshair;
    private InventoryControll inventoryControll;
    private WorkbenchControll workbenchControll;
    private BoxControll boxControll;

    private Vector3 originalPositionInventory;
    private Vector3 originalPositionWorkbench;
    private Vector3 originalPositionBox;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryOpen = false;
        fpc = fpcObject.GetComponent<FirstPersonController>();
        blockInteraction = fpcObject.GetComponent<BlockInteraction>();
        crosshair = GameObject.Find("Crosshair");
        inventoryControll = inventory.GetComponent<InventoryControll>();
        
        workbenchControll = workbench.GetComponent<WorkbenchControll>();
        boxControll = box.GetComponent<BoxControll>();
       
        
        originalPositionInventory = inventory.transform.position;
        
        originalPositionWorkbench = workbench.transform.position;
        originalPositionBox = box.transform.position;

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
            OpenUI(inventoryOpen);
        }
        if(Input.GetKeyUp(KeyCode.Escape))
        {   
            OpenUI(false);
            inventoryOpen = false;
            inventory.gameObject.SetActive(inventoryOpen);
        }
        
        
        // Sorgt für das befreien des Cursors und entfernt das Kreuz in der Mitte falls ein Fenster offen ist. 
        /*/if (inventoryOpen || craftingOpen || boxOpen)
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
            
            boxControll.RefreshBox();
        }
        */
    }
    public void OpenUI(bool isOpen)
    {
        if (isOpen)
        {
            fpc.m_MouseLook.SetCursorLock(false);
            //blockInteraction.enabled = false;
            crosshair.SetActive(false);
            // TODO RotateView ausstellen? 
        }
        else
        {
            fpc.m_MouseLook.SetCursorLock(true);
            //blockInteraction.enabled = true;
            toolTip.gameObject.SetActive(false);
            crosshair.SetActive(true);
            inventoryControll.ClearCraftingField(false);
            inventoryControll.RefreshInventory();
            
            workbenchControll.ClearCraftingField(false);
            workbenchControll.RefreshWorkbench();
            
            boxControll.RefreshBox();
        }
    }

}
