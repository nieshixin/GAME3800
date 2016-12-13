using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowEnemyDescription : MonoBehaviour {
    [SerializeField]
    EnemyBase descriptionFor;

    public void SetEnemy(EnemyBase enemy)
    {
        descriptionFor = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if (descriptionFor != null)
        {
            RefreshDescription();
        }
    }


    public void AddNewDescription(string description)
    {
       
        GetComponent<Text>().text += "- " + description;
		GetComponent<Text>().text += System.Environment.NewLine;
    }


    public void RefreshDescription()
    {
        GetComponent<Text>().text = "";
        foreach (Trait at in descriptionFor.traits)
        {
            if (at.currentValue >= 80)
            {
                AddNewDescription(at.goodDescription);
            }

            if (at.currentValue < 80 && at.currentValue >= 40)
            {
                AddNewDescription(at.normalDescription);
                //Debug.Log ("normal triggered");
            }

            if (at.currentValue < 40)
            {
                AddNewDescription(at.badDescription);
                //Debug.Log ("bad triggered");
            }
        }


    }
}
