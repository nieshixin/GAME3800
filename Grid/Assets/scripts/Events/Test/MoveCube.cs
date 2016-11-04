using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	[SerializeField]
	private Vector3 sizeStep = new Vector3(.1f, .1f, .1f);
	private Vector3 maxSize = new Vector3(5, 5, 5);
	private Vector3 minSize = new Vector3(.3f, .3f, .3f);

	public void left(BaseEvent e)
	{
		e.transform.Translate (Vector2.left * 1);

	}

	public void right(BaseEvent e)
	{
		e.transform.Translate (Vector2.right * 1);
	}
}
