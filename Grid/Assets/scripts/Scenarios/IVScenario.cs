using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IVScenario : MonoBehaviour {

	public void OnTrigger(BaseEvent e) {
		// 
		GameObject textgui = GameObject.FindGameObjectWithTag("EventDescription_UI");
		textgui.GetComponent<Text>().text = "I'm stupid";
	}
}
