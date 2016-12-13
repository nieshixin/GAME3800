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
		myReactionList.Add (ActionManager.ALL_ACTIONS.TRI_THIS);
		myReactionList.Add (ActionManager.ALL_ACTIONS.TRI_PUNCH);
		myReactionList.Add (ActionManager.ALL_ACTIONS.POP_DANCING);
		myReactionList.Add (ActionManager.ALL_ACTIONS.SHOUT);
		myReactionList.Add (ActionManager.ALL_ACTIONS.ATTACK);
		myReactionList.Add (ActionManager.ALL_ACTIONS.PUNCH);
		myReactionList.Add (ActionManager.ALL_ACTIONS.TUITION);
		myReactionList.Add (ActionManager.ALL_ACTIONS.TEACH);
		myReactionList.Add (ActionManager.ALL_ACTIONS.PILL);
		myReactionList.Add (ActionManager.ALL_ACTIONS.FISHING);
		myReactionList.Add (ActionManager.ALL_ACTIONS.BULL_CHARGE);
		myReactionList.Add (ActionManager.ALL_ACTIONS.FART);

		//adding Traits

		Trait physical = new Trait ("Physical", Trait.Type.PHYSICAL, "Feeling healthy", "A little bit hurt", "Almost ded", 100, 100, "Better", "You are physically injured.");
		Trait mental = new Trait ("Mental", Trait.Type.MENTAL, "Feeling Great", "Sad", "Supa Depressed", 100, 100, "Better", "Your tiny heart was slightly broken.");

		listOfTraits.Add (physical);
		listOfTraits.Add (mental);

		defeated = "Garbage, you were defeated!";
	}

	public void moveUp() {
		if (!locker) {
            StartCoroutine(Move(Vector2.up));
		}

	}
	public void moveR() {
		if (!locker) {
            StartCoroutine(Move(Vector2.right));
        }
	}
	public void moveL() {
		if (!locker) {
            StartCoroutine(Move(Vector2.left));
        }
	}
	public void moveDown() {
		if (!locker) {
            StartCoroutine(Move(Vector2.down));
        }
	}

    private IEnumerator Move(Vector2 dVector)
    {
        lockPlayer();

        Vector2 endLocation = transform.position + new Vector3(dVector.x, dVector.y, 0);
        float duration = .55f;
        float timeStep = 1f / 50f;
        Vector2 dVectorPerStep = dVector * timeStep / duration;
        float startTime = Time.time;

        while (Time.time <= startTime + duration)
        {
            transform.Translate(dVectorPerStep);
            yield return new WaitForFixedUpdate();
        }
        transform.position = endLocation;
        unlockPlayer();

        // trigger current event
        BaseEvent e = GetCurrentEvent();
        if (e)
        {
            e.Trigger();
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
		else if (enemyAction == "TRI_THIS") {
			Trait traitAffected = GetTrait(Trait.Type.MENTAL);
			actionTaken = string.Format ("The {0} approach you slowly with a smile on their face, two of them grabbed you by the arm making u unable to move, then the oldest brother approach you from behind and 적극적으로 당신의 자식을 삽입. After everything is over you swore to yourself not to tell anyone what just happend.", 
				enemyname, enemyAction, traitAffected.decrementResponse);

			traitAffected.currentValue -= 40;
		}
		else if (enemyAction == "TRI_PUNCH") {
			Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("Each one of the {0} give you a punch in your face. {2}", 
				enemyname, enemyAction, traitAffected.decrementResponse);

			traitAffected.currentValue -= 20;
		}
		else if (enemyAction == "POP_DANCING") {
			Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("The {0} start SHITTY and terrible {1} and your eyes are injured.", 
				enemyname, enemyAction, traitAffected.decrementResponse);

			traitAffected.currentValue -= 10;
		}
		else if (enemyAction == "SHOUT") {
			Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("The {0} start {1}ing at you 'I AM FROM BU!'. Then nothing happens.", 
				enemyname, enemyAction);

//			traitAffected.currentValue -= 10;
		}
		else if (enemyAction == "PUNCH" || enemyAction == "KICK" || enemyAction == "ATTACK") {
			Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("The {0} tries to {1} you, but {0} can not see you because his eyes are blocked by his hat!", 
				enemyname, enemyAction);

			traitAffected.currentValue -= 0;
		}
		else if (enemyAction == "TUITION") {
			Trait traitAffected = GetTrait(Trait.Type.MENTAL);
			actionTaken = string.Format ("The {0} decides to raise the {1} fees for another 100%, you felt heart broken", 
				enemyname, enemyAction);

			traitAffected.currentValue -= 20;
		}
		else if (enemyAction == "TEACH") {
			Trait traitAffected = GetTrait(Trait.Type.MENTAL);
			actionTaken = string.Format ("The {0} injected 20cc of knowledge in your brain, you felt fullfilled but also dirty.", 
				enemyname, enemyAction);
			
			traitAffected.currentValue -= 10;
		}
		else if (enemyAction == "PILL") { 
			actionTaken = string.Format ("The {0} whoop out 20 vitamin {1}s and starts putting them into his body. ", 
				enemyname, enemyAction);
			GameObject.Find ("EnemyManager").GetComponent<President> ().GetTrait (Trait.Type.PHYSICAL).currentValue += 100;
		}
		else if (enemyAction == "FISHING") {
			Trait traitAffected = GetTrait(Trait.Type.MENTAL);
			actionTaken = string.Format ("The {0} whoop out a fishing pod out of nowhere and starts {1}. What the f*** is he doing?? You felt totally fucked in the mind. ", 
				enemyname, enemyAction);

			traitAffected.currentValue -= 5;
		}
		else if (enemyAction == "BULL_CHAGER") {
			Trait traitAffected = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("The {0} starts making sounds as if he is trying really ard to poop, he suddenly {1} you with his horn.", 
				enemyname, enemyAction);
			traitAffected.currentValue -= 25;
			GameObject.Find ("EnemyManager").GetComponent<President> ().GetTrait (Trait.Type.PHYSICAL).currentValue -= 20;
		}
		else if (enemyAction == "FART") {
			Trait traitAffected = GetTrait(Trait.Type.MENTAL);
			Trait traitAffected2 = GetTrait(Trait.Type.PHYSICAL);
			actionTaken = string.Format ("The {0} unleash 20 cc of poison gas into the air, and the result is fabulous.", 
				enemyname, enemyAction);
			traitAffected2.currentValue -= 20;
			traitAffected.currentValue -= 20;
		}


		return actionTaken;
	}

	//Giving response when player is NOT taken the given action
	public string ActionNotTaken(string enemyAction, string enemyname) {
		actionNotTaken = string.Format ("{0} tries to {1} you but you have a tough ass! Damage Avoid.", 
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
