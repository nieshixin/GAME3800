using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyBase : MonoBehaviour {

    //all action effects takeplace in enemy scripts, each enemy can have different reactions towards actions
    //below is the list of actions that enemy can respond:
    public List<ActionTaker.AVAILABLE_ACTIONS> myReactionList = new List<ActionTaker.AVAILABLE_ACTIONS>();

    //helper function to check when a text input was received, if it was in the actionlist also in the enemy's reaction list.
    internal bool CanTakeAction(string PlayerTextInput)
    {
        if ((Enum.IsDefined(typeof(ActionTaker.AVAILABLE_ACTIONS), PlayerTextInput)) &&
            myReactionList.Contains(((ActionTaker.AVAILABLE_ACTIONS)(Enum.Parse(typeof(ActionTaker.AVAILABLE_ACTIONS), PlayerTextInput)))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
