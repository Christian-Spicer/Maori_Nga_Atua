using UnityEngine;
using System.Collections;

public class AutowalkArrowScript : MonoBehaviour {
	
	private CardboardHead head;
	public float delayTime = 2.0f;
	private float delay = 0.0f;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time > delay) { 
			GameObject FPSController = GameObject.Find ("Head");
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
			autowalk.checkAutoWalk = !autowalk.checkAutoWalk;
			delay = Time.time + delayTime;
		}
		// currently looking at object
		else if (isLookedAt) {
			Material material = GetComponent<Renderer>().material;
			material.SetColor("_Color", new Color(255, 255, 0, 0.1f));
		} 
		// not looking at object
		else if (!isLookedAt) { 
			Material material = GetComponent<Renderer>().material;
			material.SetColor("_Color", new Color(0, 255, 0, 0.1f));
			delay = Time.time + delayTime;
		} 

	}
}