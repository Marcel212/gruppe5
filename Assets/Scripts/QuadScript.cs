using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
    Block.BlockType buildtype = Block.BlockType.AIR;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Block b = World.GetWorldBlock(this.transform.position);
        b.BuildBlock(buildtype);
    }
}
