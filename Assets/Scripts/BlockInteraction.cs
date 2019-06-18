using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehavior that uses player inputs for interacting with the world using raycasts.
/// </summary>
public class BlockInteraction : MonoBehaviour
{
	InventoryControll inventoryControll;
	public GameObject cam;
	Block.BlockType buildtype = Block.BlockType.AIR;
	
    /// <summary>
    /// Unity lifecycle update. Pressing numbers on the keyboard selects a block type for placement.
    /// Placing a block is done with a right click.
    /// A left click damages blocks, which got hit by a raycast.
    /// </summary>
	void Update ()
    {
		Block temp = World.GetWorldBlock(this.transform.position);
		List<Item> liste = temp.inventoryControll.GetItemsInHotkey();
		if(Input.GetKeyDown("1"))
			switch(liste[0].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
              
           }
		if(Input.GetKeyDown("2"))
			switch(liste[1].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		if(Input.GetKeyDown("3"))
			switch(liste[2].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		if(Input.GetKeyDown("4"))
			switch(liste[3].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		if(Input.GetKeyDown("5"))
			switch(liste[4].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
        if (Input.GetKeyDown("6"))
            switch(liste[5].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		   if (Input.GetKeyDown("7"))
            switch(liste[6].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		   if (Input.GetKeyDown("8"))
            switch(liste[7].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		   if (Input.GetKeyDown("9"))
            switch(liste[8].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
		   if (Input.GetKeyDown("0"))
            switch(liste[9].name)
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
			   default:
					buildtype = Block.BlockType.AIR;
			   break;
		   }
        // If left or right mouse button
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            
   			// Raycast starting from the position of the crosshair
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
            {
   				Chunk hitc;
   				if(!World.chunks.TryGetValue(hit.collider.gameObject.name, out hitc)) return;

   				Vector3 hitBlockPosition;
   				if(Input.GetMouseButtonDown(0))
   				{
   					hitBlockPosition = hit.point - hit.normal/2.0f; // in case we want to hit a block
   					
   				}
   				else
   				 	hitBlockPosition = hit.point + hit.normal/2.0f; // in case we want to place a block
				
				Block b = World.GetWorldBlock(hitBlockPosition);
				hitc = b.owner;

				bool update = false; // Update determines whether a block got destroyed.
                if (Input.GetMouseButtonDown(0))
                {
                    update = b.HitBlock();
                }
                else
                {
                    update = b.BuildBlock(buildtype);
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
}
