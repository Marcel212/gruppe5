﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryInteraction : MonoBehaviour
{

    [SerializeField] private GameObject fpcObject;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject toolTip;
    private bool inventoryOpen;
    private FirstPersonController fpc;
    private BlockInteraction blockInteraction;
    private GameObject crosshair;
    
    // Start is called before the first frame update
    void Start()
    {
        inventoryOpen = false;
        fpc = fpcObject.GetComponent<FirstPersonController>();
        blockInteraction = fpcObject.GetComponent<BlockInteraction>();
        crosshair = GameObject.Find("Crosshair");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventoryOpen = !inventoryOpen;
            inventory.gameObject.SetActive(inventoryOpen);
            

        }

        if (inventoryOpen)
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

        }
    }




    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Wenn der Collider ein InventarItem ist, füge es hinzu 
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.GetComponent<InventoryControll>().AddItem(item);
        }
    }
}
