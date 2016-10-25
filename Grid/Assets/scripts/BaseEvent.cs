using UnityEngine;
using System;
using System.Collections;

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
