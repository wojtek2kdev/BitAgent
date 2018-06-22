using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserSound : MonoBehaviour {

	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		audio.Play ();
		audio.time = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			Destroy (gameObject);
		}
	}
}
