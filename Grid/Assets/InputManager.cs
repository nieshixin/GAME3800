using UnityEngine;
using System.Collections;
using UnityEditor.Events;	
public class InputManager : MonoBehaviour {
	public GameObject currentEnemy;
	public EnemyScenario es;
	public int sindex;
	public TriBroScenario ktb;
//	public EnemyBase enemy;

	// Use this for initialization
	void Start () {
		sindex = 0;
		es = GameObject.Find ("ScenarioManager").GetComponent<EnemyScenario> ();
		ktb = GameObject.Find ("ScenarioManager").GetComponent<TriBroScenario> ();
	}
	public void handleInput() 
	{
		switch (sindex) {
		case 1:
			es.HandleInput ();
			break;
		case 2:
			ktb.HandleInput ();
			break;
		default:
			break;		
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
