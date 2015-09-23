using UnityEngine;
using System.Collections;

public class TeleportFromMountainScript : MonoBehaviour {

	private CardboardHead head;
	public float delayTime = 2.0f;
	private float delay = 0.0f;
	public Texture firstTexture;
	public Texture secondTexture;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds, enable/disable autowalk
		if (isLookedAt && Time.time > delay) { 
			Cardboard.SDK.Recenter ();
			head.transform.position = new Vector3(-30.42f,6f,36.32f);
			GameObject FPSController = GameObject.Find ("Head");
			FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
			autowalk.checkAutoWalk = false;
			delay = Time.time + delayTime;
		}
		// currently looking at object
		else if (isLookedAt) {
			Material material = GetComponent<Renderer>().material;
			material.mainTexture = secondTexture;
		} 
		// not looking at object
		else if (!isLookedAt) { 
			Material material = GetComponent<Renderer>().material;
			material.mainTexture = firstTexture;
			delay = Time.time + delayTime;
		} 
	}
}
