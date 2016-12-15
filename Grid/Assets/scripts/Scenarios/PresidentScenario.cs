using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class PresidentScenario : MonoBehaviour {

	private Canvas uiCanvas;
	private Text battleLogTextUI;
	private Button talkButton;
	private int scenarioScriptIndex = 0;
	private BaseEvent theEvent;
	private player player;
	private InputField playerinput;
	private DynamicScrollView battleLog;
	private Text NpcUI;
	private ShowEnemyDescription showEnemyDescription;

	private InputManager inputmg;

	public Sprite defAvt;
	private List<string> scenarioScript;
	private int ScenarioIndex = 4;
	public Sprite avt;
	private Image avatar;
	public President enemy;

	public bool defeated  = false;
	void Start()
	{
		//		battleLogTextUI = GameObject.FindGameObjectWithTag(Tags.BATTLE_LOG_TEXT_UI).GetComponent<Text>();
		battleLog = GameObject.FindGameObjectWithTag(Tags.DYNAMIC_BATTLE_LOG).GetComponent<DynamicScrollView>();
		talkButton = GameObject.FindGameObjectWithTag(Tags.TALK_BUTTON).GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
		playerinput = GameObject.FindGameObjectWithTag (Tags.PLAYER_INPUT_FIELD).GetComponent<InputField> ();
		playerinput.enabled = false;
		showEnemyDescription = GameObject.FindGameObjectWithTag(Tags.ENEMY_DESCRIPTION_UI).GetComponent<ShowEnemyDescription>();

		NpcUI = GameObject.FindGameObjectWithTag (Tags.NPC_NAME).GetComponent<Text> ();
		inputmg = GameObject.Find ("InputManager").GetComponent<InputManager> ();

		avatar = GameObject.FindGameObjectWithTag (Tags.ENEMY_AVATAR).GetComponent<Image> ();
		//Initialize Enemy
		//		enemy = GameObject.Find("EnemyManager").GetComponent<enemyExample>();

		//		Debug.Log("Enemy Name INIT: " + enemy.EnemyName);

		scenarioScript = new List<string>() {
			" It's time! ",
			" You have to finally face the Evil President!", 
			" The Evil President is 336 years old.",
			" And he has ONE famous Momento: ",
			" Respect me! I am OLD! ",
			" Now, Time to fight. "


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
				battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
				//				
			} else {
				scenarioScript.Add (enemy.ActionNotTaken (input));
				battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
				//				
			}
		}

		if (enemy.IsDead ()) {
			battleLog.AddNewElement(enemy.defeated);
			defeated = true;
			playerinput.enabled = false;
		} else {
			//Enemy Generate Action towards player
			string enemyAction = enemy.GenerateAction();
			Debug.Log("Enemy takes action: " + enemyAction);
			if (player.CanTakeAction (enemyAction)) {
				scenarioScript.Add(player.ActionTaken (enemyAction, enemy.EnemyName));
				battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
				//				
			} else {
				scenarioScript.Add(player.ActionNotTaken (enemyAction, enemy.EnemyName));
				battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
				//				
			}
			if (player.IsDead ()) {
				battleLog.AddNewElement(player.defeated);
				//				
				playerinput.enabled = false;
			}
		}



		Debug.Log ("Enemy status: " + enemy.GetTrait(Trait.Type.PHYSICAL).currentValue.ToString () + " / " + enemy.GetTrait(Trait.Type.MENTAL).currentValue.ToString ());
		Debug.Log ("Player status: " + player.GetTrait(Trait.Type.PHYSICAL).currentValue.ToString () + " / " + player.GetTrait(Trait.Type.MENTAL).currentValue.ToString ());	
	}

	public void EnemyTurn() {

	}

	public void OnTrigger(BaseEvent e)
	{	


		//		scenarioScript = new List<string>() {
		//			"Oh Shit!",
		//			"The " + enemy.EnemyName + " suddenly blocks your way, what do you wanna do?"
		//
		//		};

		theEvent = e;
		uiCanvas = theEvent.UICanvas;

		NpcUI.text = enemy.EnemyName;
		// Lock player movement
		player.lockPlayer();

		//		battleLogTextUI.text = GetNextScriptAndAdvanceIndex();
		battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());

		talkButton.onClick.AddListener(OnTalk);
		player.lockPlayer ();

		showEnemyDescription.SetEnemy(enemy);
		//
		avatar.sprite = avt;

		inputmg.sindex = ScenarioIndex;

		player.Reset();
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
			//			battleLogTextUI.text += "\n\n";
			//			battleLogTextUI.text += GetNextScriptAndAdvanceIndex();
			battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
			Debug.Log (scenarioScriptIndex.ToString ());
		}


	}

	private void RebuildScenario() {
		if (defeated) {
			string[] initText = 
			{
				"You had defeated" + enemy.EnemyName + ", he's laying on the ground and lost his consciousness."

			};
			scenarioScript = new List<string>(initText);
		}
		else {
			scenarioScript = new List<string>() {
				" It's time! ",
				" You have to finally face the Evil President!", 
				" The Evil President is 336 years old.",
				" And he has ONE famous Momento: ",
				" Respect me! I am OLD! ",
				" Now, Time to fight. "


			};
		}
			
		battleLog.ClearOldElement();
		NpcUI.text = "";

		//Reset character for testing purpose
		//enemy.Reset ();
		//player.Reset ();
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

		inputmg.sindex = 0;
		avatar.sprite = defAvt;
	}

	void update() {

	}
}
