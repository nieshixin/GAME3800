using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class enemyExample : MonoBehaviour {

	//all action effects takeplace in enemy scripts, each enemy can have different reactions towards actions
	//below is the list of actions that enemy can respond:
	public List<ActionTaker.AVAILABLE_ACTIONS> myReactionList = new List<ActionTaker.AVAILABLE_ACTIONS>();


	// Use this for initialization
	void Start () {
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionTaker.AVAILABLE_ACTIONS.cry);
		myReactionList.Add(ActionTaker.AVAILABLE_ACTIONS.laugh);
	}

	// Update is called once per frame
	void Update () {

	}

	//helper function to check when a text input was received, if it was in the actionlist also in the enemy's reaction list.
	bool CanTakeAction(string PlayerTextInput){
		if ((Enum.IsDefined (typeof(ActionTaker.AVAILABLE_ACTIONS), PlayerTextInput)) &&
			myReactionList.Contains(((ActionTaker.AVAILABLE_ACTIONS)(Enum.Parse (typeof(ActionTaker.AVAILABLE_ACTIONS),PlayerTextInput)))))  {
			return true;			
		} else {
			return false;
		}
	}



}
