﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class President : EnemyBase {


	private player player;
	// Use this for initialization
	void Start () {
		Debug.Log ("Initialize Enemy");
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionManager.ALL_ACTIONS.DAVID);
		myReactionList.Add(ActionManager.ALL_ACTIONS.TAUNT);
		myReactionList.Add(ActionManager.ALL_ACTIONS.FUCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.SHIT);
		myReactionList.Add(ActionManager.ALL_ACTIONS.PUNCH);
		myReactionList.Add(ActionManager.ALL_ACTIONS.ATTACK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.MOCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.TICKLE);
		myReactionList.Add(ActionManager.ALL_ACTIONS.HORN);





		//
		myActionList.Add(ActionManager.ALL_ACTIONS.TUITION);
		myActionList.Add(ActionManager.ALL_ACTIONS.TEACH);
		myActionList.Add(ActionManager.ALL_ACTIONS.PILL);
		myActionList.Add(ActionManager.ALL_ACTIONS.FISHING);
		myActionList.Add(ActionManager.ALL_ACTIONS.BULL_CHARGE);
		myActionList.Add(ActionManager.ALL_ACTIONS.FART);


		this.EnemyName = "Evil President";
		//Declaring Traits
		traits.Add(new Trait("Physical", Trait.Type.PHYSICAL, "I'm feeling good!", "Not so healthy", "Almost dead", 100, 100, "It's pain for you, but it's joy for them.", "Enemy gets slightly injured."));
		traits.Add(new Trait ("Mental", Trait.Type.MENTAL, "Super duper", "Not Cool", "Mentally Breaking down", 100, 100, "They suddenly get hyped!", ""));
		//traits.Add(new Trait ("Mental", Trait.Type.MENTAL, "Super duper", "Not Cool", "Mentally Breaking down", 100, 100, "They suddenly get hyped!", ""));
		//traits.Add(new Trait ("Age", Trait.Type.MENTAL, "Super duper", "Not Cool", "Mentally Breaking down", 100, 100, "They suddenly get hyped!", ""));
		this.defeated = "Congradulations! You defeat " + EnemyName + "!" + "\nHowever, they run into 3 different directions so it's impossible to chase them down!";
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
		Debug.Log (myActionList [UnityEngine.Random.Range(0, myActionList.Count)].ToString ());
	}

	// Giving feedback when enemy is taken the given action.
	public string ActionTaken(string PlayerTextInput) {

		if (PlayerTextInput == "MOCK" || PlayerTextInput == "TAUNT") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You tried to {0} the {1}, but AT WHAT COST? He has been {0} for 300+ years. He taunted you back as if you are the worthless pievce of shit.", 
				PlayerTextInput, this.EnemyName);
			player.GetTrait (Trait.Type.MENTAL).currentValue -= 50;

		}
		else if (PlayerTextInput == "FUCK") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = "What the hell are you thinking about? This is a serious game!";
			//				string.Format ("What the hell are you thinking about? This is a serious game!", 
			//				PlayerTextInput, this.EnemyName, affectedTrait.incrementResponse);
			//			affectedTrait.currentValue += 15;

		}
		else if (PlayerTextInput == "SHIT") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = "Watch your LANGUAGE! Use some civilized words please!";
			//				string.Format ("Watch your LANGUAGE! Use some civilized words please!", 
			//				PlayerTextInput, this.EnemyName, affectedTrait.incrementResponse);
			//			affectedTrait.currentValue -= 10;
		}
		else if (PlayerTextInput == "DAVID") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You start singing a song which lyrics is all about {0}, the {1} start to cry",
				PlayerTextInput, this.EnemyName);
			affectedTrait.currentValue -= 100;
		}


		else if (PlayerTextInput == "PUNCH" || PlayerTextInput == "ATTACK" || PlayerTextInput == "KICK") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = string.Format ("You decide to {0} the {1}. Guess what? It really works! You don't even feel bad for {0} a old man, good for you!",
				PlayerTextInput, this.EnemyName);
			//			affectedTrait.currentValue -=;
			affectedTrait.currentValue -= 20;
		}
		else if (PlayerTextInput == "TICKLE") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = string.Format ("You decided to {0} the {1}. while you are tickling him you hear his bone shatter a little bit. He laughed so hard that one of his jaw came off.",
				PlayerTextInput, this.EnemyName);
			affectedTrait.currentValue -= 30;
		}
		else if (PlayerTextInput == "HORN") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = string.Format ("You decide to grab the {1} by the horn and pee on his face. The old man almost drown to death",
				PlayerTextInput, this.EnemyName);
			affectedTrait.currentValue -= 100;
		}



		return actionTaken;

	}

	// Giving feedback when enemy is NOT taken the given action.
	public string ActionNotTaken(string PlayerTextInput) {
		this.actionNotTaken = string.Format ("You decide to {0} the {1} but failed because he wasn't paying attention, for he is busy molesting freshman students  that are walking to their classes.", 
			PlayerTextInput, this.EnemyName);
		GetTrait(Trait.Type.PHYSICAL).currentValue -= 10;
		GetTrait(Trait.Type.MENTAL).currentValue += 30;
			
		return actionNotTaken;
	}



}
