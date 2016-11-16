using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class enemyExample : EnemyBase {

	// Use this for initialization
	void Start () {
		//so from all available actions: laugh, cry, mock, this enemy accept 2 of them
		myReactionList.Add(ActionTaker.AVAILABLE_ACTIONS.cry);
		myReactionList.Add(ActionTaker.AVAILABLE_ACTIONS.laugh);
	}


}
