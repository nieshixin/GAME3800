using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public class player : MonoBehaviour {

	public bool locker = false;
	public string actionTaken;
	public string actionNotTaken;
	public string defeated;
	public List<ActionManager.ALL_ACTIONS> myReactionList = new List<ActionManager.ALL_ACTIONS>();

	public List<Trait> listOfTraits = new List<Trait>();

    public Trait GetTrait(Trait.Type type)
    {
        return Trait.GetTrait(type, listOfTraits);
    }

    //helper function to check when a text input was received, if it was in the in the player's reaction list.
    internal bool CanTakeAction(string EnemyAction)
	{
		if ((Enum.IsDefined(typeof(ActionManager.ALL_ACTIONS), EnemyAction)) &&
			myReactionList.Contains(((ActionManager.ALL_ACTIONS)(Enum.Parse(typeof(ActionManager.ALL_ACTIONS), EnemyAction)))))
		{
			return true;
		}
		else
		{
			return false;
		}
	}
		


	// Use this for initialization
	void Start () {
		//initialize player's reaction list
		myReactionList.Add (ActionManager.ALL_ACTIONS.SLAP);
		myReactionList.Add (ActionManager.ALL_ACTIONS.MOCK);

		//adding Traits

		Trait physical = new Trait ("Physical", Trait.Type.PHYSICAL, "Feeling healthy", "Just another day", "Feel painful", 100, 100, "Better", "You are physically injured.");
		Trait mental = new Trait ("Mental", Trait.Type.MENTAL, "good", "meh", "saw justin bieber today", 100, 100, "Better", "Your tiny heart is slightly broken.");

		listOfTraits.Add (physical);
		listOfTraits.Add (mental);

		defeated = "Garbage, you were defeated!";
	}

	public void moveUp() {
		if (!locker) {
			transform.Translate (Vector2.up * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}

	}
	public void moveR() {
		if (!locker) {
			transform.Translate (Vector2.right * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}
	public void moveL() {
		if (!locker) {
			transform.Translate (Vector2.left * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}
	public void moveDown() {
		if (!locker) {
			transform.Translate (Vector2.down * 1);
			BaseEvent e = GetCurrentEvent ();
			if (e) {
				e.Trigger ();
			}
		}
	}

	private BaseEvent GetCurrentEvent() {
		return TileManager.GetAllGameTiles ()
			.Where (gameObj => gameObj.transform.position == transform.position)
			.Select(gameObj => gameObj.GetComponent<BaseEvent>())
			.First ();
	}

	// Player movement locker
	public void lockPlayer() {
		
		if (!locker) {
			locker = true;
		}
	}

	//Player movement Unlocker
	public void unlockPlayer() {
		if (locker) {
			locker = false;
		}
	}

	//Giving response when player is taken the given action
	public string ActionTaken(string enemyAction, string enemyname) {
		if (enemyAction == "SLAP") {
            Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("{0} badly {1}s you with no hesitation! {2}", 
				enemyname, enemyAction, traitAffected.decrementResponse);

            traitAffected.currentValue -= 30;
		} else if (enemyAction == "MOCK") {
            Trait traitAffected = GetTrait(Trait.Type.MENTAL);
            actionTaken = string.Format ("Damn! {0} is {1}ing you! what a Humiliation! {2}", 
				enemyname, enemyAction, traitAffected.decrementResponse);

            traitAffected.currentValue -= 40;
        }

		return actionTaken;
	}

	//Giving response when player is NOT taken the given action
	public string ActionNotTaken(string enemyAction, string enemyname) {
		actionNotTaken = string.Format ("{0} tries to {1} you but you have a tough ass! Damage Aviod.", 
			enemyname, enemyAction);

		return actionNotTaken;
	}

	// Check if player is defeated
	public bool IsDead() {
		return GetTrait(Trait.Type.PHYSICAL).currentValue <= 0 || GetTrait(Trait.Type.MENTAL).currentValue <= 0;
	}

	// Reset player's condition
	public void Reset() {
        Trait physical = GetTrait(Trait.Type.PHYSICAL);
        Trait mental = GetTrait(Trait.Type.MENTAL);

        physical.currentValue = physical.maxValue;
        mental.currentValue = mental.maxValue;
	}
}
