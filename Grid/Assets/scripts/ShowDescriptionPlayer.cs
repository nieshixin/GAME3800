using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShowDescriptionPlayer : MonoBehaviour {
	// Use this for initialization
	player theplayer;

	void Start () {
		theplayer = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
	}
	
	// Update is called once per frame
	void Update () {
		RefreshDescription ();
		
	}
		

	public void AddNewDescription(string description){
		GetComponent<Text>().text += System.Environment.NewLine;
		GetComponent<Text>().text += description;
	}
		

	public void RefreshDescription(){
		GetComponent<Text> ().text = "";
		foreach (Trait at in theplayer.listOfTraits) {
				if (at.currentValue >= 80) {
					AddNewDescription (at.goodDescription);
					}
        
			if (at.currentValue < 80 && at.currentValue >= 40) {
				AddNewDescription (at.normalDescription);
				//Debug.Log ("normal triggered");
					}
        
			 if (at.currentValue < 40) {
				AddNewDescription (at.badDescription);
				//Debug.Log ("bad triggered");
					}
				}


		}
}
