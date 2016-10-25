using System;
using UnityEngine;
using System.Collections;

public class MainQuestEvent : BaseEvent {

    public override void OnTrigger(object sender, EventArgs e)
    {
        Debug.Log("Starting main quest");   
    }

    public override void OnFinish(object sender, EventArgs e)
    {
        Debug.Log("Finished main quest");
    }
}
