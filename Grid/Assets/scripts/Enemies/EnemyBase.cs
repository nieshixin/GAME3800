using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyBase : MonoBehaviour {

    //all action effects takeplace in enemy scripts, each enemy can have different reactions towards actions
    //below is the list of actions that enemy can respond:
    public List<ActionManager.ALL_ACTIONS> myReactionList = new List<ActionManager.ALL_ACTIONS>();

	// List of actions that enemy can use
	public List<ActionManager.ALL_ACTIONS> myActionList = new List<ActionManager.ALL_ACTIONS> ();


	public string EnemyName;
	public Attribute physical;
	public Attribute mental;
	public string actionTaken;
	public string actionNotTaken;
	public string defeated;


    //helper function to check when a text input was received, if it was in the actionlist also in the enemy's reaction list.
    internal bool CanTakeAction(string PlayerTextInput)
    {
        if ((Enum.IsDefined(typeof(ActionManager.ALL_ACTIONS), PlayerTextInput)) &&
			myReactionList.Contains(((ActionManager.ALL_ACTIONS)(Enum.Parse(typeof(ActionManager.ALL_ACTIONS), PlayerTextInput)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	// Validate enemy death
	public bool IsDead() {
		return physical.currentValue <= 0 || mental.currentValue <= 0;
	}

	// Reset Enemy's condition
	public void Reset() {
		physical.currentValue = physical.maxValue;
		mental.currentValue = mental.maxValue;
	}

	// Randomly select one available action in enemy's action list
	public string GenerateAction() {
		int ActionIndex = UnityEngine.Random.Range (0, myActionList.Count);
		string myAction = myActionList [ActionIndex].ToString ();
		return myAction.ToUpper();
	}
}
