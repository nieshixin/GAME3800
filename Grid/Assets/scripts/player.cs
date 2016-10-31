using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	public void moveUp() {
		transform.Translate (Vector2.up * 1);

	}
	public void moveR() {
		transform.Translate (Vector2.right * 1);

	}
	public void moveL() {
		transform.Translate (Vector2.left * 1);

	}
	public void moveDown() {
		transform.Translate (Vector2.down * 1);

	}

	// Update is called once per frame
	void Update () {
	}
}
