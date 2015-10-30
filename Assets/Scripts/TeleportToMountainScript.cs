//the controls the teleport to the top of the mountain
using UnityEngine;
using System.Collections;

public class TeleportToMountainScript : MonoBehaviour {
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
			GameObject controller = GameObject.Find ("PlayerCapsule");
			//this put the charactor to the top of the mountain
			controller.transform.position = new Vector3(60f,41f,0f);
			//this finds the script that contains the boolean checkAutoWalk
            CharacterMotor autowalk = controller.GetComponent<CharacterMotor>();
			//this set the boolean checkAutoWalk to false
			autowalk.checkAutoWalk = false;
			//this gets the god of war object
			GameObject animationManager = GameObject.Find ("Tumatauenga");
			////this gets the script that handles the animation
			Animation animation = animationManager.GetComponent<Animation>();
			//this plays the animation
			animation.Play ();
			//this get the audio manager object
			GameObject audioManager = GameObject.Find ("AudioManager");
			//this get the script that handle the changing of the audio files
			InputHandlerScript audio = audioManager.GetComponent<InputHandlerScript>();
			//this changes the audio boolen in InputHandlerScript 
			audio.Koauau = false;
			audio.Putatara = false;
			if (animation["GodOfWarTake1"].enabled && animation["GodOfWarTake1"].time == 0)
				audio.Haka = true;
			else 
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
