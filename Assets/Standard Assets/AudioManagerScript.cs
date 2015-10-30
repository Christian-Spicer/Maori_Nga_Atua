using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Audio/AudioSource")]
public class AudioManagerScript : MonoBehaviour {

	//stores the names of files
	public string[] audioName;
	//store all the audoi that we want to use
	public AudioClip[] audioClip;
	[System.NonSerialized]
	//this is to activate the log message 
	public bool clipFound;
	//declares a variable 
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		//initialize the variable
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//this controls the the files to play
	public void PlaySound(string clipName)
	{
		//loops though the files the are in the list
		for (int i = 0; i < audioName.Length; i++) {
			//if the file name = one in the list 
			if (clipName == audioName [i]) {
				//assign file to clip
				audio.clip = audioClip [i];
				//plays the file
				if (audio) {
					audio.volume = 1.5f;
					if(audio.isPlaying)return;
					audio.Play();

				}
				clipFound = true;
				break;
			} else {
				clipFound = false;
			}
		}
		if (!clipFound) {
			Debug.Log("Audio Clip not found!");
		}
	}
}
