using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class IVScenario : MonoBehaviour {

	private Canvas uiCanvas;
	private Text battleLogTextUI;
	private Button talkButton;
	private int scenarioScriptIndex = 0;
	private BaseEvent theEvent;
	private player player;
	private DynamicScrollView battleLog;

	void Start()
	{
//		battleLogTextUI = GameObject.FindGameObjectWithTag(Tags.BATTLE_LOG_TEXT_UI).GetComponent<Text>();
		battleLog = GameObject.FindGameObjectWithTag(Tags.DYNAMIC_BATTLE_LOG).GetComponent<DynamicScrollView>();
		talkButton = GameObject.FindGameObjectWithTag(Tags.TALK_BUTTON).GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
	}

	List<string> scenarioScript = new List<string>
	{
		" You walked in the dining hall and see a bunch of dead food.",
		" Luckily there isnt any dead fellow NEU students.",
		" Actually, there isnt any person in here at all. ", 
		" You found a pizza that is still alive. 'save my daughter, her future is still bright.' ", 
		" You choise to save his daugter. Then you eat her. "
	};

	private string GetNextScriptAndAdvanceIndex()
	{
		string result = scenarioScriptIndex >= scenarioScript.Count ? "" : scenarioScript[scenarioScriptIndex];
		scenarioScriptIndex++;
		return result;
	}

	public void OnTrigger(BaseEvent e)
	{

		theEvent = e;
		uiCanvas = theEvent.UICanvas;

		// Lock player movement
		player.lockPlayer();

//		battleLogTextUI.text = GetNextScriptAndAdvanceIndex();
		battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());

		talkButton.onClick.AddListener(OnTalk);

	}

	private void OnTalk()
	{
		if (scenarioScriptIndex >= scenarioScript.Count)
		{
			ScenarioFinished();
		} else
		{
//			battleLogTextUI.text += "\n\n";
//			battleLogTextUI.text += GetNextScriptAndAdvanceIndex();
			battleLog.AddNewElement(GetNextScriptAndAdvanceIndex());
		}
	}


	private void ScenarioFinished()
	{
		scenarioScriptIndex = 0;
		talkButton.onClick.RemoveListener(OnTalk);
		theEvent.Finish();
		battleLog.ClearOldElement();

		// Unclock Player movement
		player.unlockPlayer();
	}
}
