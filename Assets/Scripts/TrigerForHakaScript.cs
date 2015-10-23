using UnityEngine;
using System.Collections;

public class TrigerForHakaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
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
		audio.Haka = true;
	}
	void OnTriggerExit(Collider other)
	{
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
		audio.Koauau = true;
		audio.Putatara = false;
		audio.Haka = false;
	}
}
