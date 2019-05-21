using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryInteraction : MonoBehaviour
{

    [SerializeField] private GameObject m_FPC_Object;
    [SerializeField] private GameObject m_Inventory;
    
    private bool m_InventoryOpen;
    private FirstPersonController m_FPC;
    private BlockInteraction m_BlockInteraction;
    
    // Start is called before the first frame update
    void Start()
    {
        m_InventoryOpen = false;
        m_FPC = m_FPC_Object.GetComponent<FirstPersonController>();
        m_BlockInteraction = m_FPC_Object.GetComponent<BlockInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenInventory();
    }
    
    private void OpenInventory()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            m_InventoryOpen = !m_InventoryOpen;
            m_Inventory.transform.GetChild(0).gameObject.SetActive(m_InventoryOpen);
            m_Inventory.transform.GetChild(1).gameObject.SetActive(m_InventoryOpen);

        }
        
        if (m_InventoryOpen)
        {
            m_FPC.m_MouseLook.SetCursorLock(false);
            m_BlockInteraction.enabled = false;
            // TODO RotateView ausstellen? 
        }
        else
        {
            m_FPC.m_MouseLook.SetCursorLock(true);
            m_BlockInteraction.enabled = true;
            m_FPC.RotateView();
        }
            
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Wenn der Collider ein InventarItem ist, füge es hinzu 
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            m_Inventory.GetComponent<InventoryControll>().AddItem(item);
        }
    }
}
