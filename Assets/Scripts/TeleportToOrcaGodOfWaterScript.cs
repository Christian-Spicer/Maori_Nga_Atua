//the controls the teleport to view the whale e.g. the god of water
using UnityEngine;
using System.Collections;

public class TeleportToOrcaGodOfWaterScript : MonoBehaviour {
	//this declares a variable for the head in google cardboard
	private CardboardHead head;
	//this declares the variable for the time it takes to activate the teleport
	public float delayTime = 2.0f;
	//this declares a variable that gets set to compare against delayTime variable
	private float delay = 0.0f;
	//this declares a variable for the first texture
	public Texture firstTexture;
	//this declares a variable for the second texture
	public Texture secondTexture;
	// Use this for initialization
	void Start () {
		//this sets the head variable to the Head component
		head = Camera.main.GetComponent<StereoController>().Head;
	}
	// Update is called once per frame
	void Update () {
		//this declares the hit variable as a raycast
		RaycastHit hit;
		//this gets a true or false from the raycast component
		bool isLookedAt = GetComponent<Collider> ().Raycast (head.Gaze, out hit, Mathf.Infinity);
		// if looking at object for 2 seconds
		if (isLookedAt && Time.time > delay) {
			//this gets the head component
            GameObject controller = GameObject.Find("PlayerCapsule");
			//this put the charactor to the whale
			controller.transform.position = new Vector3(85f,7f,-70f);
			//this finds the script that contains the boolean checkAutoWalk
            CharacterMotor autowalk = controller.GetComponent<CharacterMotor>();
			//this set the boolean checkAutoWalk to false
			autowalk.checkAutoWalk = false;
			//this get the audio manager object
			GameObject audioManager = GameObject.Find ("AudioManager");
			//this get the script that handle the changing of the audio files
			InputHandlerScript audio = audioManager.GetComponent<InputHandlerScript>();
			//this changes the boolean in the InputHanderScript 
			audio.Koauau = false;
			audio.Putatara = true;
			audio.Haka = false;
			//this line set the delay to count down
			delay = Time.time + delayTime;
		}
		// currently looking at object
		else if (isLookedAt) {
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color of the pole
			material.mainTexture = secondTexture;
		} 
		// not looking at object
		else if (!isLookedAt) { 
			//this sets a variable of the component 
			Material material = GetComponent<Renderer>().material;
			//this set the color of the pole
			material.mainTexture = firstTexture;
			//this line set the delay to count down
			delay = Time.time + delayTime;
		} 
	}
}

