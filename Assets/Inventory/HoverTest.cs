using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!ItemTextControll.visible)
        {
            gameObject.SetActive(false);
        }
    }
}
