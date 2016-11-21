using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	public void SendPlayerInput(string input){
		input = GetComponent<InputField>().text;
		Debug.Log (input);
	}

	public void ClearInputBar(){
		GetComponent<InputField> ().text = "";


	}
}
