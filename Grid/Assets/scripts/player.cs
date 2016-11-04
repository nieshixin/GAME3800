using UnityEngine;
using System.Collections;
using System.Linq;

public class player : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	public void moveUp() {
		transform.Translate (Vector2.up * 1);
		BaseEvent e = GetCurrentEvent ();
		if (e) {
			e.Trigger ();
		}

	}
	public void moveR() {
		transform.Translate (Vector2.right * 1);
		BaseEvent e = GetCurrentEvent ();
		if (e) {
			e.Trigger ();
		}

	}
	public void moveL() {
		transform.Translate (Vector2.left * 1);
		BaseEvent e = GetCurrentEvent ();
		if (e) {
			e.Trigger ();
		}

	}
	public void moveDown() {
		transform.Translate (Vector2.down * 1);
		BaseEvent e = GetCurrentEvent ();
		if (e) {
			e.Trigger ();
		}
	}

	private BaseEvent GetCurrentEvent() {
		return TileManager.GetAllGameTiles ()
			.Where (gameObj => gameObj.transform.position == transform.position)
			.Select(gameObj => gameObj.GetComponent<BaseEvent>())
			.First ();
	}
}
