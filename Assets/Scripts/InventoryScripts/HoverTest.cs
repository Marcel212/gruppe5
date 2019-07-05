using UnityEngine;

public class HoverTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!ToolTipControll.visible)
        {
            gameObject.SetActive(false);
        }
    }
}
