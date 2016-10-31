using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// A base event describes a base in-game event that can be triggered. BaseEvents also have the ability to trigger an OnFinish event.
/// 
/// To use:
///     Let's say I want to open a window when this event is triggered.
///     
///     I have some WindowManager.cs script which has some function 'OpenNewWindow(object, EventArgs)' that opens a new window
///     
///     In WindowManager.cs, I need to subscribe this method I defined to the event that I want to trigger the window opening.
///     Let's call this event 'myEvent,' and let's assume we're currently in the WindowManager.cs script file.
///     
///     To subscribe the method to the event, just call
///         myEvent.AddOnTrigger(OpenNewWindow)
///         
///     Most likely, you want to call this on script initialization (e.g. Awake/Start). What this does is tells the event to call the method
///     'OpenNewWindow' whenever the 'Triggered' event is called.
/// </summary>
public class BaseEvent : MonoBehaviour
{
    private event EventHandler Triggered;
    private event EventHandler Finished;

    // Use this for initialization
    protected void Start()
    {
        AddOnTrigger(OnTrigger);
        AddOnTrigger(OnFinish);
    }


    public void TestTrigger()
    {
        Triggered(this, EventArgs.Empty);
    }

    #region Event Boilerplate

    public void AddOnTrigger(EventHandler eh)
    {
        Triggered += eh;
    }

    public void RemoveOnTrigger(EventHandler eh)
    {
        Triggered -= eh;
    }

    public void AddOnFinished(EventHandler eh)
    {
        Finished += eh;
    }

    public void RemoveOnFinished(EventHandler eh)
    {
        Finished -= eh;
    }

    #endregion

    public virtual void OnTrigger(object sender, EventArgs e)
    {
        Debug.Log("ON TRIGGER called with sender \"" + sender + "\", and event args \"" + e + "\"");
    }

    public virtual void OnFinish(object sender, EventArgs e)
    {
        Debug.Log("ON FINISH called with sender \"" + sender + "\", and event args \"" + e + "\"");
    }
}
