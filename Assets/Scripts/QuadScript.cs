using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{

    public GameObject inventory;
    public InventoryControll inventoryControll;
    public ScriptableManagerScript scriptableManagerScript;
    Item item;
    Block.BlockType buildtype = Block.BlockType.AIR;
    public bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (destroy)
       {
           Block b = World.GetWorldBlock(this.transform.position);
           b.blocksize = Block.Blocksize.BIG;
           b.BuildBlock(buildtype);
           this.gameObject.SetActive(false);
       }
    } 
    private void OnTriggerExit(Collider other)
    {
        destroy = true;
        Block b = World.GetWorldBlock(this.transform.position);
        switch(b.blockType)
           {
               case Block.BlockType.GRASS:
                    item = scriptableManagerScript.GetItemByName("Erde");
                    inventoryControll.AddItem(item);
               break;
           }
    }
}
