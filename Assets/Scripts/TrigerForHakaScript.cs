using UnityEngine;
using System.Collections;

public class TrigerForHakaScript : MonoBehaviour {

	private GameObject animationManager;
	private Animation animation;
	private GameObject audioManager;
	private InputHandlerScript audio;
	private AudioSource tumatauengaAudioSource;
	private GameObject audioTumatauenga;
	// Use this for initialization
	void Start () {
		//this gets the god of war object
		animationManager = GameObject.Find ("Tumatauenga");
		////this gets the script that handles the animation
		animation = animationManager.GetComponent<Animation>();
		//this get the audio manager object
		audioManager = GameObject.Find ("AudioManager");
		//this get the script that handle the changing of the audio files
		audio = audioManager.GetComponent<InputHandlerScript>();
		//this get the audio manager object
		audioTumatauenga = GameObject.Find ("Tumatauenga");
		//this get the controls the audio for the haka
		tumatauengaAudioSource = audioTumatauenga.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		//this plays the animation
		animation.Play ();
		//this get the audio manager object
		//this changes the audio boolen in InputHandlerScript 
		audio.Koauau = false;
		audio.Putatara = false;
		if (animation["GodOfWarTake1"].enabled && animation["GodOfWarTake1"].time == 0)
			audio.Haka = true;
		else 
			audio.Haka = false;
	}
	void OnTriggerExit(Collider other)
	{
		//this stops the animation
		animation.Stop ();
		tumatauengaAudioSource.Stop ();
		//this changes the audio boolen in InputHandlerScript 
		audio.Koauau = true;
		audio.Putatara = false;
		audio.Haka = false;
	}
	void OnStay()
	{
		audio.Koauau = false;
		audio.Putatara = false;
		if (animation["GodOfWarTake1"].enabled && animation["GodOfWarTake1"].time == 0)
			audio.Haka = true;
		else 
			audio.Haka = false;
	}
}
