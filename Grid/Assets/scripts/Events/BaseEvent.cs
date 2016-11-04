using UnityEngine;
using UnityEngine.Events;
using System;

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

    [System.Serializable]
    private sealed class BaseEventUnityEvent : UnityEvent<BaseEvent> { }


    [SerializeField]
    private BaseEventUnityEvent Triggered;
    [SerializeField]
    private BaseEventUnityEvent Finished;

    // Use this for initialization
    protected void Start()
    {
        AddOnTrigger(OnTrigger);
		AddOnFinished(OnFinish);
    }


    public void Trigger()
    {
        Triggered.Invoke(this);
    }

    public void Finish()
    {
        Finished.Invoke(this);
    }

    #region Event Boilerplate

    public void AddOnTrigger(UnityAction<BaseEvent> action)
    {
        Triggered.AddListener(action);
    }

    public void RemoveOnTrigger(UnityAction<BaseEvent> action)
    {
        Triggered.RemoveListener(action);
    }

    public void AddOnFinished(UnityAction<BaseEvent> action)
    {
        Finished.AddListener(action);
    }

    public void RemoveOnFinished(UnityAction<BaseEvent> action)
    {
        Finished.RemoveListener(action);
    }

    #endregion

    public virtual void OnTrigger(BaseEvent e)
    {
        Debug.Log("ON TRIGGER called for event " + e);
    }

    public virtual void OnFinish(BaseEvent e)
    {
        Debug.Log("ON FINISH called for event " + e);
    }
}
