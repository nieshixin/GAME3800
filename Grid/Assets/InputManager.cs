using UnityEngine;
using System.Collections;
public class InputManager : MonoBehaviour {
	public GameObject currentEnemy;
	public EnemyScenario es;
	public int sindex;
	public TriBroScenario ktb;
	public BUGuyScenario bug;
	public PresidentScenario pres;
//	public EnemyBase enemy;

	// Use this for initialization
	void Start () {
		sindex = 0;
		es = GameObject.Find ("ScenarioManager").GetComponent<EnemyScenario> ();
		ktb = GameObject.Find ("ScenarioManager").GetComponent<TriBroScenario> ();
		bug = GameObject.Find ("ScenarioManager").GetComponent<BUGuyScenario> ();
		pres = GameObject.Find ("ScenarioManager").GetComponent<PresidentScenario> ();

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
		case 3:
			bug.HandleInput ();
			break;
		case 4:
			pres.HandleInput ();
			break;
		default:
			break;		
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
