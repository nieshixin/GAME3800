using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BUGUY : EnemyBase {

	private player player;
	// Use this for initialization
	void Start () {
		Debug.Log ("Initialize Enemy");
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionManager.ALL_ACTIONS.DAVID);
		myReactionList.Add(ActionManager.ALL_ACTIONS.MOCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.FUCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.SHIT);
		myReactionList.Add(ActionManager.ALL_ACTIONS.PUNCH);
		myReactionList.Add(ActionManager.ALL_ACTIONS.ATTACK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.KICK);


		//
		myActionList.Add(ActionManager.ALL_ACTIONS.SHOUT);
		myActionList.Add(ActionManager.ALL_ACTIONS.PUNCH);
		myActionList.Add(ActionManager.ALL_ACTIONS.KICK);
		myActionList.Add(ActionManager.ALL_ACTIONS.ATTACK);


		this.EnemyName = "A BU GUY";
		//Declaring Traits
		traits.Add(new Trait("Physical", Trait.Type.PHYSICAL, "I'm feeling good!", "Not so healthy", "Almost dead", 100, 100, "It's pain for you, but it's joy for them.", "Enemy gets slightly injured."));
		traits.Add(new Trait ("Mental", Trait.Type.MENTAL, "Super duper", "Not Cool", "Mentally Breaking down", 100, 100, "They suddenly get hyped!", ""));
		this.defeated = "Congradulations! You defeat " + EnemyName + "!" + "\n However it would be a miracle if you can't defeat him, because HE CAN't HURT you...";
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
		Debug.Log (myActionList [UnityEngine.Random.Range(0, myActionList.Count)].ToString ());
	}

	// Giving feedback when enemy is taken the given action.
	public string ActionTaken(string PlayerTextInput) {
		
		if (PlayerTextInput == "MOCK") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You fail to talk to {0} since he is completed sinked into the music world!", 
				this.EnemyName);
//			affectedTrait.currentValue -= 34;

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
			this.actionTaken = string.Format ("You decide to {0} the {1} in his face.{1} shouted :'OUCH!'. {2}",
				PlayerTextInput, this.EnemyName, affectedTrait.decrementResponse);
			//			affectedTrait.currentValue -=;
			affectedTrait.currentValue -= 34;
		}

		return actionTaken;

	}

	// Giving feedback when enemy is NOT taken the given action.
	public string ActionNotTaken(string PlayerTextInput) {
		this.actionNotTaken = string.Format ("{1} do not know what you are doing, ", 
			PlayerTextInput, this.EnemyName, this.EnemyName);

		return actionNotTaken;
	}

		

}
