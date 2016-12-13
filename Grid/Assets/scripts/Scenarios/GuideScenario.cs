using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GuideScenario : MonoBehaviour {

	private Canvas uiCanvas;
	private Text battleLogTextUI;
	private Button talkButton;
	private int scenarioScriptIndex = 0;
	private BaseEvent theEvent;
	private player player;
	private DynamicScrollView battleLog;

	private Image avatar;

	public Sprite defavatar;

	void Start()
	{
		//		battleLogTextUI = GameObject.FindGameObjectWithTag(Tags.BATTLE_LOG_TEXT_UI).GetComponent<Text>();
		battleLog = GameObject.FindGameObjectWithTag(Tags.DYNAMIC_BATTLE_LOG).GetComponent<DynamicScrollView>();
		talkButton = GameObject.FindGameObjectWithTag(Tags.TALK_BUTTON).GetComponent<Button>();
		player = GameObject.FindGameObjectWithTag (Tags.PLAYER).GetComponent<player> ();

		avatar = GameObject.FindGameObjectWithTag (Tags.ENEMY_AVATAR).GetComponent<Image> ();
	}

	List<string> scenarioScript = new List<string>
	{
		" USER GUIDE! ",
		" Welcome to the NORTHEASTERN ODYSSEY! ",
		" Here IS the USER GUIDE! ", 
		" Use arrow keys to navigate. ", 
		" THAT'S ALL! ",
		" NOW ",
		" GET THE HELL OUTTA HERE! "
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

		avatar.sprite = defavatar;

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
