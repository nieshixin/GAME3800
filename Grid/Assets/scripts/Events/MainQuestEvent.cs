using System;
using UnityEngine;
using System.Collections;

public class MainQuestEvent : BaseEvent {

    public override void OnTrigger(BaseEvent e)
    {
        Debug.Log("Starting main quest");
    }

    public override void OnFinish(BaseEvent e)
    {
        Debug.Log("Finished main quest");
    }
}
