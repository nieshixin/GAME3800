using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hint_2 : MonoBehaviour {

	private Canvas uiCanvas;
	private Text battleLogTextUI;
	private Button talkButton;
	private int scenarioScriptIndex = 0;
	private BaseEvent theEvent;
	private player player;
	private DynamicScrollView battleLog;


	void Start()
	{
		//        battleLogTextUI = GameObject.FindGameObjectWithTag(Tags.BATTLE_LOG_TEXT_UI).GetComponent<Text>();
		battleLog = GameObject.FindGameObjectWithTag(Tags.DYNAMIC_BATTLE_LOG).GetComponent<DynamicScrollView>();
		talkButton = GameObject.FindGameObjectWithTag(Tags.TALK_BUTTON).GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();
	}

	List<string> scenarioScript = new List<string>
	{
		"A guy approaches you and seems to be worried about something",
		"He says:",
		"'There were brothers bullying around for months, they were so powerful that nobody can beat them.'" +
		" physical attack seems to be useless against them. " +
		" but using language abuse works a little bit.",
		" However all these are not the most important ",
		" These brothers are very sensitive against things relate to SAT ",
		" it might does something with their pathetic childhood ",
		" just try to remind them that when you see them ",
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

		//        battleLogTextUI.text = GetNextScriptAndAdvanceIndex();
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
			//            battleLogTextUI.text += "\n\n";
			//            battleLogTextUI.text += GetNextScriptAndAdvanceIndex();
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
