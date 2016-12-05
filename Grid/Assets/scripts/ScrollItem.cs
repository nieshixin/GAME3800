using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollItem : MonoBehaviour
{

    
    public Text indexText;

    public DynamicScrollView dynamicScrollView;
   
    void OnEnable()
    {
        indexText.text = transform.name;
    }

    public void OnRemoveMe()
    {
        DestroyImmediate(gameObject);
        dynamicScrollView.SetContentHeight();
    }



}
