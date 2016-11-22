using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour {

	public string currentInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	public void SendPlayerInput(){
		currentInput = GetComponent<InputField>().text;
	}

	public void ClearInputBar(){
		GetComponent<InputField> ().text = "";


	}
}
