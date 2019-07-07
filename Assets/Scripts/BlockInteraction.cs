﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehavior that uses player inputs for interacting with the world using raycasts.
/// </summary>
public class BlockInteraction : MonoBehaviour
{
	int temp2 = -1;
	InventoryControll inventoryControll;
	public GameObject cam;
	Block.BlockType buildtype = Block.BlockType.AIR;
	public bool craftingOpen = true;
	private bool boxOpen = true;
	 private GameObject workbench;
	 private GameObject box;
	 private Vector3 originalPositionBox;

	private Vector3 originalPositionWorkbench;
	
    /// <summary>
    /// Unity lifecycle update. Pressing numbers on the keyboard selects a block type for placement.
    /// Placing a block is done with a right click.
    /// A left click damages blocks, which got hit by a raycast.
    /// </summary>

	void Start()
	{
		workbench = GameObject.Find("CraftingBench");
		originalPositionWorkbench = workbench.transform.position;
		box = GameObject.Find("KistenUI");
		originalPositionBox = box.transform.position;
	}

	void Update ()
    {
			

		Block temp = World.GetWorldBlock(this.transform.position);
		List<Item> liste = temp.inventoryControll.GetItemsInHotkey();
		//int temp2 = -1;
		if(Input.GetKeyDown("1"))
		{
			setBuildType(liste,0);
			temp2 = 0;
        }
		if(Input.GetKeyDown("2"))
		{
			setBuildType(liste,1);
			temp2 = 1;
		}
		if(Input.GetKeyDown("3"))
		{
			setBuildType(liste,2);
			temp2 = 2;
		}
		if(Input.GetKeyDown("4"))
		{
			setBuildType(liste,3);
			temp2 = 3;
		}
		if(Input.GetKeyDown("5"))
		{
			setBuildType(liste,4);
			temp2 = 4;
		}
        if (Input.GetKeyDown("6"))
        {
			setBuildType(liste,5);
			temp2 = 5;
		}
		if (Input.GetKeyDown("7"))
        {
			setBuildType(liste,6);
			temp2 = 6;
		}
		if (Input.GetKeyDown("8"))
         {
			setBuildType(liste,7);
			temp2 = 7;
		}
	    if (Input.GetKeyDown("9"))
        {
			setBuildType(liste,8);
			temp2 = 8;
		}
		if (Input.GetKeyDown("0"))
        {
			setBuildType(liste,9);
			temp2 = 9;
		}
        // If left or right mouse button
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)|| Input.GetKeyDown("c")|| Input.GetKeyDown("l"))
        {
            RaycastHit hit;
            
   			// Raycast starting from the position of the crosshair
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
            {
   				Chunk hitc;
   				if(!World.chunks.TryGetValue(hit.collider.gameObject.name, out hitc)) return;

   				Vector3 hitBlockPosition;
   				if(Input.GetMouseButtonDown(0)||Input.GetKeyDown("c")||Input.GetKeyDown("l"))
   				{
   					hitBlockPosition = hit.point - hit.normal/2.0f; // in case we want to hit a block
   					
   				}
   				else
   				 	hitBlockPosition = hit.point + hit.normal/2.0f; // in case we want to place a block
				
				Block b = World.GetWorldBlock(hitBlockPosition);
				hitc = b.owner;

				bool update = false; // Update determines whether a block got destroyed.
				if(Input.GetKeyDown("c"))
				{
					if(b.blockType == Block.BlockType.WORKBENCH)
					{
						workbench.transform.position = originalPositionWorkbench;
            			craftingOpen = !craftingOpen;
           				workbench.gameObject.SetActive(craftingOpen);
					}
				}
				if (Input.GetKeyDown("l") && b.blockType == Block.BlockType.TRUNK)
        		{
            		box.transform.position = originalPositionBox;
            		boxOpen = !boxOpen;
            		box.gameObject.SetActive(boxOpen);
        		}
                if (Input.GetMouseButtonDown(0))
                {
                    update = b.HitBlock();
                }
				if(Input.GetMouseButtonDown(1))
                {
					if(temp2 >= 0)
					{
						if(temp.inventoryControll.RemoveOneItemInHotKey(temp2))
						{
							if(!(buildtype == Block.BlockType.DOORDOWN || buildtype == Block.BlockType.DOORTOP))
							{
								update = b.BuildBlock(buildtype);
							}
							if(!(b.HasSolidNeighbour((int)b.position.x,(int)b.position.y + 1,(int)b.position.z))&& buildtype == Block.BlockType.DOORDOWN)
							{
								update = b.BuildBlock(buildtype);
								b = b.getTop();
								if(update){update = b.BuildBlock(Block.BlockType.DOORTOP);}
							}
						}
						else
						{
							buildtype = Block.BlockType.AIR;
						}
					}
                }

                // If a block got destroyed, redraw the chunk and affected neighbouring chunks.
				if(update)
   				{
   					hitc.changed = true;
	   				List<string> updates = new List<string>();
	   				float thisChunkx = hitc.chunk.transform.position.x;
	   				float thisChunky = hitc.chunk.transform.position.y;
	   				float thisChunkz = hitc.chunk.transform.position.z;

	   				// Update affected neighbours
	   				if(b.position.x == 0) 
	   					updates.Add(World.BuildChunkName(new Vector3(thisChunkx-World.chunkSize,thisChunky,thisChunkz)));
					if(b.position.x == World.chunkSize - 1) 
						updates.Add(World.BuildChunkName(new Vector3(thisChunkx+World.chunkSize,thisChunky,thisChunkz)));
					if(b.position.y == 0) 
						updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky-World.chunkSize,thisChunkz)));
					if(b.position.y == World.chunkSize - 1) 
						updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky+World.chunkSize,thisChunkz)));
					if(b.position.z == 0) 
						updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky,thisChunkz-World.chunkSize)));
					if(b.position.z == World.chunkSize - 1) 
						updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky,thisChunkz+World.chunkSize)));

		   			foreach(string cname in updates)
		   			{
		   				Chunk c;
						if(World.chunks.TryGetValue(cname, out c))
						{
							c.Redraw();
				   		}
				   	}
				}
		   	}
   		}
	}
	public void setBuildType(List<Item> items, int position)
	{
		switch(items[position].name)
           {
               case "Erde":
					buildtype = Block.BlockType.DIRT;
			   break;
			   case "Holzstamm":
					buildtype = Block.BlockType.WOOD;
			   break;
			   case "Stein":
					buildtype = Block.BlockType.STONE;
			   break;
			   case "Werkbank":
			   		buildtype = Block.BlockType.WORKBENCH;
			   break;
			   case "Diamant":
					buildtype = Block.BlockType.DIAMOND;
			   break;
			   case "Gold":
					buildtype = Block.BlockType.GOLD;
			   break;
			   case "Truhe":
					buildtype = Block.BlockType.TRUNK;
			   break;
			   case "RedStone":
			   		buildtype = Block.BlockType.REDSTONE;
			   break;
			   case "Holzbretter":
			   		buildtype = Block.BlockType.PLANK;
			   break;
			   case "Tuer":
			   		buildtype = Block.BlockType.DOORDOWN;
			   break;
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
              
           }
	}
}
