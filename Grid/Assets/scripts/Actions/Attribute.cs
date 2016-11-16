using UnityEngine;
using System.Collections;

[System.Serializable]
public struct Attribute {

    public string name;
    public string description;
    public int maxValue;
    public int currentValue;
    public string incrementResponse;   // what is returned when the value is incremented
    public string decrementResponse;   // what is returned when the value decremented

    public bool Is(float val)
    {
        return currentValue == val;
    }

    public string Increment()
    {
        currentValue = Mathf.Min(maxValue, currentValue + 1);
        return incrementResponse;
    }

    public string Decrement()
    {
        currentValue = Mathf.Max(0, currentValue - 1);
        return decrementResponse;
    }
}
