using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class KoreanTriBro : EnemyBase {
	private player player;
	// Use this for initialization
	void Start () {
		Debug.Log ("Initialize Enemy");
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionManager.ALL_ACTIONS.SAT);
		myReactionList.Add(ActionManager.ALL_ACTIONS.DAVID);
		myReactionList.Add(ActionManager.ALL_ACTIONS.MOCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.FUCK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.SHIT);
		myReactionList.Add(ActionManager.ALL_ACTIONS.PUNCH);
		myReactionList.Add(ActionManager.ALL_ACTIONS.ATTACK);
		myReactionList.Add(ActionManager.ALL_ACTIONS.KICK);


		//
		myActionList.Add(ActionManager.ALL_ACTIONS.POP_DANCING);
		myActionList.Add(ActionManager.ALL_ACTIONS.TRI_PUNCH);
		myActionList.Add(ActionManager.ALL_ACTIONS.TRI_THIS);
		myActionList.Add(ActionManager.ALL_ACTIONS.KICK);
		myActionList.Add(ActionManager.ALL_ACTIONS.SLEEP);


		this.EnemyName = "Korean Tri-Bro";
		//Declaring Traits
		traits.Add(new Trait("Physical", Trait.Type.PHYSICAL, "I'm feeling good!", "Not so healthy", "Almost ded", 100, 100, "It's pain for you, but it's joy for them.", "Enemy gets slightly injured."));
		traits.Add(new Trait ("Mental", Trait.Type.MENTAL, "Super duper", "Not Cool", "Mentally Breaking down", 100, 100, "They suddenly get hyped!", "They pull out their father's photo and start crying!"));
		this.defeated = "Congradulations! You defeat " + EnemyName + "!" + "\nHowever, they run into 3 different directions so it's impossible to chase them down!";
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
		Debug.Log (myActionList [UnityEngine.Random.Range(0, myActionList.Count)].ToString ());
	}

	// Giving feedback when enemy is taken the given action.
	public string ActionTaken(string PlayerTextInput) {
		if (PlayerTextInput == "SAT") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You look at them in the eyes, ask:'which one of you has the highest {0} score?', they are terribly shocked, and {2}", 
				PlayerTextInput, this.EnemyName, affectedTrait.decrementResponse);
			affectedTrait.currentValue -= 100;

		}
		else if (PlayerTextInput == "MOCK") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You talk to {1}:'Your father must be proud of you very much!'. Your {0} reminds them of their father, and {2}", 
				PlayerTextInput, this.EnemyName, affectedTrait.decrementResponse);
			affectedTrait.currentValue -= 34;

		}
		else if (PlayerTextInput == "FUCK") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = string.Format ("You are outnumbered by {1} and you still want to {0} them? {2}", 
				PlayerTextInput, this.EnemyName, affectedTrait.incrementResponse);
			affectedTrait.currentValue += 15;

		}
		else if (PlayerTextInput == "SHIT") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You take off your pants and unleash some brown matter, then you invite {1} to come and smell it, they then found out that it was actually {0}.", 
				PlayerTextInput, this.EnemyName, affectedTrait.incrementResponse);
			affectedTrait.currentValue -= 10;
		}
		else if (PlayerTextInput == "DAVID") {
			Trait affectedTrait = GetTrait(Trait.Type.MENTAL);
			this.actionTaken = string.Format ("You start singing a song which lyrics is all about {0}, the {1} start to cry",
				PlayerTextInput, this.EnemyName);
			affectedTrait.currentValue -= 100;
		}


		else if (PlayerTextInput == "PUNCH" || PlayerTextInput == "ATTACK" || PlayerTextInput == "KICK") {
			Trait affectedTrait = GetTrait(Trait.Type.PHYSICAL);
			this.actionTaken = string.Format ("You decide to {0} the {1}..... BUT WHICH ONE??? You receive tri-{0} back!",
				PlayerTextInput, this.EnemyName);
//			affectedTrait.currentValue -=;
			player.GetTrait(Trait.Type.PHYSICAL).currentValue -= 30;
		}

		return actionTaken;

	}

	// Giving feedback when enemy is NOT taken the given action.
	public string ActionNotTaken(string PlayerTextInput) {
		this.actionNotTaken = string.Format ("{1} do not know what you are doing, they shout at you:'톰은 바보 같은 놈이야.'", 
			PlayerTextInput, this.EnemyName, this.EnemyName);

		return actionNotTaken;
	}

}
