using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerPositionManager : MonoBehaviour {

	[SerializeField]
	GameObject player;

	enum MOVE_DIRECTION {
		UP, DOWN, LEFT, RIGHT
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Tile");

		foreach (GameObject  tile in tiles) {
			if (tile.transform.position == player.transform.position) {
				tile.GetComponent<BoxCollider2D> ().enabled = false;
			}
			if (tile.transform.position != player.transform.position) {
				tile.GetComponent<BoxCollider2D> ().enabled = true;
			}
		}


		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			if (CanMove (MOVE_DIRECTION.UP)) {
				// move player up
				player.GetComponent<player>().moveUp();
				Debug.Log("Player moved up");
			}
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (CanMove (MOVE_DIRECTION.DOWN)) {
				// move player down
				player.GetComponent<player>().moveDown();
				Debug.Log("Player moved down");
			}	
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if (CanMove (MOVE_DIRECTION.LEFT)) {
				// move player down
				player.GetComponent<player>().moveL();
				Debug.Log("Player moved left");
			}
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if (CanMove (MOVE_DIRECTION.RIGHT)) {
				// move player down
				player.GetComponent<player>().moveR();;
				Debug.Log("Player moved right");
			}
		}
	}

	// Based on player position, get list of available moves
	Dictionary<MOVE_DIRECTION, bool> GetAvailableMoves() {
		//find tile player is currently on
		//if there is a right tile, then set RIGHT -> true
		//if there is a left tile, then set LEFT -> true
		// etc...

		Dictionary<MOVE_DIRECTION, bool> result = new Dictionary<MOVE_DIRECTION, bool> ();

		// has right?
		RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.right);

		if (hit.collider != null && (Vector2.Distance(player.transform.position, hit.collider.transform.position) <= 1) && hit.collider.transform.position != player.transform.position) {
			// then we know there is a tile here
			result.Add(MOVE_DIRECTION.RIGHT, true);
		}

		// has left?
		hit = Physics2D.Raycast(player.transform.position, Vector2.left);
		if (hit.collider != null && (Vector2.Distance(player.transform.position, hit.collider.transform.position) <= 1) && hit.collider.transform.position != player.transform.position) {
			// then we know there is a tile here
			result.Add(MOVE_DIRECTION.LEFT, true);
		}

		// has up?
		hit = Physics2D.Raycast(player.transform.position, Vector2.up);
		if (hit.collider != null && (Vector2.Distance(player.transform.position, hit.collider.transform.position) <= 1) && hit.collider.transform.position != player.transform.position) {
			// then we know there is a tile here
			result.Add(MOVE_DIRECTION.UP, true);

		}

		// has down?
		hit = Physics2D.Raycast(player.transform.position, Vector2.down);
		if (hit.collider != null && (Vector2.Distance(player.transform.position, hit.collider.transform.position) <= 1) && hit.collider.transform.position != player.transform.position) {
			// then we know there is a tile here
			result.Add(MOVE_DIRECTION.DOWN, true);
		}

		return result;
	}

	bool CanMove(MOVE_DIRECTION moveDirection) {
		Dictionary<MOVE_DIRECTION, bool> availableMoves = GetAvailableMoves ();
		bool canMove;
		availableMoves.TryGetValue (moveDirection, out canMove);
		Debug.Log ("canMove = " + canMove);
		return canMove;
	}
}
