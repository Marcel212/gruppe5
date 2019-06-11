using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
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
    }
}
