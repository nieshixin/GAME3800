using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RugglesStationScenario : MonoBehaviour {

    private Canvas uiCanvas;

    List<string> scenarioScript = new List<string>
    {
        "Walking into Ruggles, you see bunch of people running towards you. yelling screaming, shouting.",
        "You punched the guy running next to you, he seems totally okay though.",
        "'Run for your life man! Our campus has been indaded!! This is not a drill! Or maybe it is!!" +
        " I'm not really sure!! Everyone else is running so i started running as well! Actually im not sure about anything!" +
        " says the thoughtful lady."
    };

	public void OnTrigger(BaseEvent e)
    {
        uiCanvas = e.UICanvas;
    }


    public void ScenarioFinished(BaseEvent e)
    {
        e.Finish();
    }
}
