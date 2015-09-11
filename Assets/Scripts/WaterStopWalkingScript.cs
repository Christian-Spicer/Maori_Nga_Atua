using UnityEngine;
using System.Collections;

public class WaterStopWalkingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider coll)
	{
		GameObject FPSController = GameObject.Find ("Head");
		FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
		autowalk.checkAutoWalk = false;
	}
	void OnCollisionStay(Collision coll)
	{
		GameObject FPSController = GameObject.Find ("Head");
		FPSInputController autowalk = FPSController.GetComponent<FPSInputController> ();
		autowalk.checkAutoWalk = false;
	}
}
