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
		myReactionList.Add(ActionManager.ALL_ACTIONS.DAVID);

		//
		myActionList.Add(ActionManager.ALL_ACTIONS.SLAP);
		myActionList.Add(ActionManager.ALL_ACTIONS.MOCK);
		myActionList.Add(ActionManager.ALL_ACTIONS.KICK);

		this.EnemyName = "The Ultimate Douch Bag";
		//Declaring Traits
		this.physical = new Trait ("Physical", "", "", "", 100, 100, "Better", "Enemy gets slightly injured.");
		this.mental = new Trait ("Physical", "", "", "", 100, 100, "Better", "You successfully hurt his heart!");
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

		else if (PlayerTextInput == "DAVID") {
			this.actionTaken = string.Format ("You start singing a song which lyrics is all about {0}, the {1} start to cry",
				PlayerTextInput, this.EnemyName);
			this.mental.currentValue -= 100;

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
