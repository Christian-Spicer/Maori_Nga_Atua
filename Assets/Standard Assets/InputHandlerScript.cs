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
		GameObject audioTumatauenga = GameObject.Find ("Tumatauenga");
		AudioSource audioSource = audioManager.GetComponent<AudioSource> ();
		AudioSource tumatauengaAudioSource = audioTumatauenga.GetComponent<AudioSource> ();
		AudioManagerScript audio = audioManager.GetComponent<AudioManagerScript>();
		if (Koauau) {
			Putatara = false;
			Haka = false;
			Koauau = false;
			audio.PlaySound ("Koauau");
		}
		else if (Putatara) {
			Koauau = false;
			Haka = false;
			Putatara = false;
			audio.PlaySound ("Putatara");
		}
		else if (Haka) {
			Koauau = false;
			Putatara = false;
			Haka = false;
			audioSource.Stop();
			tumatauengaAudioSource.Play();
			//audio.PlaySound ("Haka");
		}
	}
}
