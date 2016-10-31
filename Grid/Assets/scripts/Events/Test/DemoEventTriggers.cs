using UnityEngine;
using System.Collections;

public class DemoEventTriggers : MonoBehaviour {

    [SerializeField]
    private Vector3 sizeStep = new Vector3(.1f, .1f, .1f);
    private Vector3 maxSize = new Vector3(5, 5, 5);
    private Vector3 minSize = new Vector3(.3f, .3f, .3f);

	public void Enlarge(BaseEvent e)
    {
        e.transform.localScale += sizeStep;
        e.transform.localScale = Vector3.Min(e.transform.localScale, maxSize);
    }

    public void Shrink(BaseEvent e)
    {
        e.transform.localScale -= sizeStep;
        e.transform.localScale = Vector3.Max(e.transform.localScale, minSize);
    }
}
