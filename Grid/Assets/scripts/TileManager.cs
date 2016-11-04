using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class TileManager {

	public static List<GameObject> GetAllGameTiles() {
		return GameObject.FindGameObjectsWithTag ("Tile").ToList();
	}
}
