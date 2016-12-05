using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RugglesStationScenario : MonoBehaviour {

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
        "Walking into Ruggles, you see bunch of people running towards you. yelling screaming, shouting.",
        "You punched the guy running next to you, he seems totally okay though.",
        "'Run for your life man! Our campus has been indaded!! This is not a drill! Or maybe it is!!" +
        " I'm not really sure!! Everyone else is running so i started running as well! Actually im not sure about anything!" +
        " says the thoughtful lady."
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
