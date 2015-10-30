//this controls the reset to reset and recentre  the charactor
using UnityEngine;
using System.Collections;

public class ResetRecenterScript : MonoBehaviour {
	//this declares a variable for the head in google cardboard
	private CardboardHead head;
	//this declares the variable for the time it takes to activate the reset
	public float delayTime = 1.0f;
	//this declares a variable that gets set to compare against delayTime variable
	private float delay = 0.0f;
    private Rigidbody rb;
    private CharacterMotor autowalk;
    GameObject controller;
	// Use this for initialization
	void Start() {
		//this sets the head variable to the Head component
		head = Camera.main.GetComponent<StereoController>().Head;
        //this gets the head component
        controller = GameObject.Find("PlayerCapsule");
        //this finds the script that contains the boolean checkAutoWalk
        autowalk = controller.GetComponent<CharacterMotor>();
			
   	}
	// Update is called once per frame
	void Update() {
		//this declares the hit variable as a raycast
		RaycastHit hit;
		//this gets a true or false from the raycast component
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time > delay) { 
			//tis recentres the player
			Cardboard.SDK.Recenter ();
            //this put the charactor back to the start 
            controller.transform.position = new Vector3(-30.42f, 9.9f, 36.32f);
            //this set the boolean checkAutoWalk to false
            autowalk.checkAutoWalk = false;
			//this line set the delay to count down
			delay = Time.time + delayTime;
		}
		// currently looking at object
		else if (isLookedAt) {
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color
			material.SetColor("_Color", new Color(255, 255, 0, 0.3f));
		} 
		// not looking at object
		else if (!isLookedAt) { 
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color
			material.SetColor("_Color", new Color(0, 0, 255, 0.3f));
			//this set the color
			delay = Time.time + delayTime;
			//this line set the delay to count down
		} 
	}
}