using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowDescription : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.J)) {
			Debug.Log ("addDescription");
			AddNewDescription (" - I'm feeling really good high af ahhhhhh");
		}
	}
		

	public void AddNewDescription(string description){
		GetComponent<Text>().text += System.Environment.NewLine;
		GetComponent<Text>().text += description;
	}
}
