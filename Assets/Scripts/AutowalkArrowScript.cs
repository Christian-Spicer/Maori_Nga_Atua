//this controls the autowalk arrow to start walking
using UnityEngine;
using System.Collections;

public class AutowalkArrowScript : MonoBehaviour {
	//this declares a variable for the head in google cardboard
	private CardboardHead head;
	//this declares the variable for the time it takes to activate the autowalk
	public float delayTime = 2.0f;
	//this declares a variable that gets set to compare against delayTime variable
	private float delay = 0.0f;
	// Use this for initialization
	void Start() {
		//this sets the head variable to the Head component
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	// Update is called once per frame
	void Update() {
		//this declares the hit variable as a raycast
		RaycastHit hit;
		//this gets a true or false from the raycast component
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		//if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time > delay) { 
			//this gets the head component
			GameObject FPSController = GameObject.Find ("Head");
			//this finds the script that contains the boolean checkAutoWalk
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
			//this set the boolean checkAutoWalk to true if it is false ans false if it is true
			autowalk.checkAutoWalk = !autowalk.checkAutoWalk;
			//this line set the delay to count down
			delay = Time.time + delayTime;
		}
		//currently looking at object
		else if (isLookedAt) {
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color
			material.SetColor("_Color", new Color(255, 255, 0, 0.1f));
		} 
		// not looking at object
		else if (!isLookedAt) { 
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color
			material.SetColor("_Color", new Color(0, 255, 0, 0.1f));
			//this line set the delay to count down
			delay = Time.time + delayTime;
		}
	}
}