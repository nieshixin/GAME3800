using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyAvatarDisplay : MonoBehaviour {

	public BaseEvent eventscript;
	public player player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
	}

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.right);
		if (hit.collider != null && hit.collider.transform.position == player.transform.position){
			eventscript = hit.collider.GetComponent<BaseEvent> ();
		}

	}

}
