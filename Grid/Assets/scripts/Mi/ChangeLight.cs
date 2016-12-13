using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChangeLight : MonoBehaviour {
	public Light biglight;
	float secondforlerp = 3;
	public bool changetriggered = false;
	float lerpvalue = 0;
	float result;
	float intensityOriginal;
	float angleOriginal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		}


	 public void OnStep(){
		
		intensityOriginal = biglight.intensity;
		angleOriginal = biglight.spotAngle;
			biglight.intensity = 8;
			biglight.spotAngle = 80;

	}
	public void OnFinished(){
		biglight.intensity = intensityOriginal;
		biglight.spotAngle = angleOriginal;
	}
}
