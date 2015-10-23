using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioManagerScript))]

public class InputHandlerScript : MonoBehaviour {
	[System.NonSerialized]
	public bool Koauau = true;
	[System.NonSerialized]
	public bool Haka = false;
	[System.NonSerialized]
	public bool Putatara = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject audioManager = GameObject.Find ("AudioManager");
		AudioManagerScript audio = audioManager.GetComponent<AudioManagerScript>();
		if (Koauau)
			audio.Play ("Koauau");
		else if (Haka)
			audio.Play ("Putatara");
		else if (Putatara)
			audio.Play ("Putatara");
	}
}
