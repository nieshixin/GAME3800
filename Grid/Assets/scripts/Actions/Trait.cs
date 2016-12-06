using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Trait {

    public enum Type
    {
        PHYSICAL, MENTAL
    }

    public Type type;
    public string name;
    public string goodDescription;
	public string normalDescription;
	public string badDescription;
    public int maxValue;
    public int currentValue;
    public string incrementResponse;   // what is returned when the value is incremented
    public string decrementResponse;   // what is returned when the value decremented

	public Trait (string name, Type type, string des1, string des2, string des3, int max, int current, string increm, string decrem) {
		this.name = name;
		this.goodDescription = des1;
		this.normalDescription = des2;
		this.badDescription = des3;
		this.maxValue = max;
		this.currentValue = current;
		this.incrementResponse = increm;
		this.decrementResponse = decrem;
        this.type = type;
	}

    public static Trait GetTrait(Type type, List<Trait> traits)
    {
        if (traits == null || traits.Count == 0 || !traits.Any(t => t.type == type)) throw new System.Exception("No trait '" + type + "' on player");
        return traits.Where(trait => trait.type == type).First();
    }

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
