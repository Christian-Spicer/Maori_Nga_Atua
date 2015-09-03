using UnityEngine;
using System.Collections;

public class ResetRecenterScript : MonoBehaviour {
	
	private CardboardHead head;
	public float delayTime = 1.0f;
	private float delay = 0.0f;

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	void Update() {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt && Time.time > delay) { 
			Cardboard.SDK.Recenter ();
			head.transform.position = new Vector3(-11.2f,14.7f,6f);
			GameObject FPSController = GameObject.Find ("Head");
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
			autowalk.checkAutoWalk = false;
			delay = Time.time + delayTime;
		}
		// currently looking at object
		else if (isLookedAt) {
			Material material = GetComponent<Renderer>().material;
			material.SetColor("_Color", new Color(255, 255, 0, 0.3f));
		} 
		// not looking at object
		else if (!isLookedAt) { 
			Material material = GetComponent<Renderer>().material;
			material.SetColor("_Color", new Color(0, 0, 255, 0.3f)); 
		} 

	}
}