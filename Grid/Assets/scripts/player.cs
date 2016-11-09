using UnityEngine;
using System.Collections;
using System.Linq;

public class player : MonoBehaviour {

	public bool locker = false;

	// Use this for initialization
	void Start () {
	
	}

	public void moveUp() {
		if (!locker) {
			transform.Translate (Vector2.up * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}

	}
	public void moveR() {
		if (!locker) {
			transform.Translate (Vector2.right * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}
	public void moveL() {
		if (!locker) {
			transform.Translate (Vector2.left * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}
	public void moveDown() {
		if (!locker) {
			transform.Translate (Vector2.down * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}

	private BaseEvent GetCurrentEvent() {
		return TileManager.GetAllGameTiles ()
			.Where (gameObj => gameObj.transform.position == transform.position)
			.Select(gameObj => gameObj.GetComponent<BaseEvent>())
			.First ();
	}

	public void lockPlayer() {
		
		if (!locker) {
			locker = true;
		}
	}

	public void unlockPlayer() {
		if (locker) {
			locker = false;
		}
	}
}
