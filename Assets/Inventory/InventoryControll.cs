using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryControll : MonoBehaviour
{
    [SerializeField] private GameObject m_FPSController;
    private Boolean isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.I))
        {
            isActive = !isActive;
            transform.GetChild(0).gameObject.SetActive(isActive);
            m_FPSController.GetComponent<FirstPersonController>().m_InventoryOpen = isActive;
            
        }


    }
}

