using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;




public class enemyExample : EnemyBase {

	// Use this for initialization
	void Start () {
		Debug.Log ("Initialize Enemy");
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionManager.ALL_ACTIONS.KICK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.MIDFINGERED);

		//
		myActionList.Add(ActionManager.ALL_ACTIONS.SLAP);
		myActionList.Add(ActionManager.ALL_ACTIONS.MOCK);
		myActionList.Add(ActionManager.ALL_ACTIONS.KICK);

		this.EnemyName = "The Ultimate Douch Bag";
		this.physical = new Attribute ("Physical", "", 100, 100, "Better", "Enemy gets slightly injured.");
		this.mental = new Attribute ("Physical", "", 100, 100, "Better", "You successfully hurt his heart!");
		this.defeated = "Congradulations! You defeat " + EnemyName + "!";

		Debug.Log (myActionList [UnityEngine.Random.Range(0, myActionList.Count)].ToString ());
	}

	// Giving feedback when enemy is taken the given action.
	public string ActionTaken(string PlayerTextInput) {
		if (PlayerTextInput == "KICK") {
			this.actionTaken = string.Format ("You decided to {0} the {1}, {2}", 
				PlayerTextInput, this.EnemyName, physical.decrementResponse);
			this.physical.currentValue -= 50;

		}
		else if (PlayerTextInput == "MIDFINGERED") {
			this.actionTaken = string.Format ("You decided to {0} the {1}, {2}", 
				PlayerTextInput, this.EnemyName, physical.decrementResponse);
			this.mental.currentValue -= 50;

		}

		return actionTaken;

	}

	// Giving feedback when enemy is NOT taken the given action.
	public string ActionNotTaken(string PlayerTextInput) {
		this.actionNotTaken = string.Format ("You decided to {0} the {1}, unfortunately the {2} does not give a fuck.", 
			PlayerTextInput, this.EnemyName, this.EnemyName);

		return actionNotTaken;
	}



}
