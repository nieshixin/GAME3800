using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EnemyScenario : MonoBehaviour {

	private Canvas uiCanvas;
	private Text battleLogTextUI;
	private Button talkButton;
	private int scenarioScriptIndex = 0;
	private BaseEvent theEvent;
	private player player;
	private InputField playerinput;



	private List<string> scenarioScript;

	public enemyExample enemy;

	void Start()
	{
		battleLogTextUI = GameObject.FindGameObjectWithTag(Tags.BATTLE_LOG_TEXT_UI).GetComponent<Text>();
		talkButton = GameObject.FindGameObjectWithTag(Tags.TALK_BUTTON).GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
		playerinput = GameObject.FindGameObjectWithTag (Tags.PLAYER_INPUT_FIELD).GetComponent<InputField> ();
		playerinput.enabled = false;

	

		//Initialize Enemy
		enemy = GameObject.Find("EnemyManager").GetComponent<enemyExample>();

		scenarioScript = new List<string>() {
			"Oh Shit!",
			"The " + enemy.EnemyName + " suddenly blocks your way, what do you wanna do?"

		};

	}

	//List<string> scenarioScript = new List<string>
	//{
//		"An ultimate douch bag suddenly blocks your way, what do you wanna do?"

//	};

	private string GetNextScriptAndAdvanceIndex()
	{
		string result = scenarioScriptIndex >= scenarioScript.Count ? "" : scenarioScript[scenarioScriptIndex];
		scenarioScriptIndex++;
		return result;
	}


	private string GetPlayerInput()
	{
		string inputaction = playerinput.GetComponent<PlayerInput> ().currentInput;
		return inputaction.ToUpper ();
	}


	public void HandleInput() 
	{
		Debug.Log ("Handle Input");
		string input = GetPlayerInput ();
		Debug.Log (input);
		if (input != "" && scenarioScriptIndex >= scenarioScript.Count) {
			if (enemy.CanTakeAction (input)) {
				scenarioScript.Add (enemy.ActionTaken (input));
				battleLogTextUI.text += "\n\n";
				battleLogTextUI.text += GetNextScriptAndAdvanceIndex ();


			} else {
				scenarioScript.Add (enemy.ActionNotTaken (input));
				battleLogTextUI.text += "\n\n";
				battleLogTextUI.text += GetNextScriptAndAdvanceIndex ();

			}
		}

		if (enemy.IsDead ()) {
			battleLogTextUI.text += "\n\n";
			battleLogTextUI.text += enemy.defeated;
			playerinput.enabled = false;
		} else {
			//Enemy Generate Action towards player
			string enemyAction = enemy.GenerateAction();
			Debug.Log("Enemy takes action: " + enemyAction);
			if (player.CanTakeAction (enemyAction)) {
				scenarioScript.Add(player.ActionTaken (enemyAction, enemy.EnemyName));
				battleLogTextUI.text += "\n\n";
				battleLogTextUI.text += GetNextScriptAndAdvanceIndex ();
			} else {
				scenarioScript.Add(player.ActionNotTaken (enemyAction, enemy.EnemyName));
				battleLogTextUI.text += "\n\n";
				battleLogTextUI.text += GetNextScriptAndAdvanceIndex ();
			}
			if (player.IsDead ()) {
				battleLogTextUI.text += "\n";
				battleLogTextUI.text += player.defeated;
				playerinput.enabled = false;
			}
		}



		Debug.Log ("Enemy status: " + enemy.physical.currentValue.ToString () + " / " + enemy.mental.currentValue.ToString ());
		Debug.Log ("Player status: " + player.physical.currentValue.ToString () + " / " + player.mental.currentValue.ToString ());	
	}

	public void EnemyTurn() {
		
	}

	public void OnTrigger(BaseEvent e)
	{

		theEvent = e;
		uiCanvas = theEvent.UICanvas;

		// Lock player movement
		player.lockPlayer();

		battleLogTextUI.text = GetNextScriptAndAdvanceIndex();

		talkButton.onClick.AddListener(OnTalk);

	}

	private void OnTalk()
	{
		
		if (scenarioScriptIndex == scenarioScript.Count - 1) {
			playerinput.enabled = true;
		}
		if (scenarioScriptIndex >= scenarioScript.Count)
		{
			if (enemy.IsDead() || player.IsDead()) {
				ScenarioFinished();
			}

		} else
		{
			battleLogTextUI.text += "\n\n";
			battleLogTextUI.text += GetNextScriptAndAdvanceIndex();
			Debug.Log (scenarioScriptIndex.ToString ());
		}
	}

	private void RebuildScenario() {
		string[] initText = 
		{
			"Oh Shit!",
			"The " + enemy.EnemyName + " suddenly blocks your way, what do you wanna do?"

		};
		scenarioScript = new List<string>(initText);

		//Reset character for testing purpose
		enemy.Reset ();
		player.Reset ();
	}

	private void ScenarioFinished()
	{
		scenarioScriptIndex = 0;
		talkButton.onClick.RemoveListener(OnTalk);
		theEvent.Finish();

		// Unclock Player movement
		player.unlockPlayer();
		playerinput.enabled = false;
		RebuildScenario ();

	}

	void update() {
		
	}
}
