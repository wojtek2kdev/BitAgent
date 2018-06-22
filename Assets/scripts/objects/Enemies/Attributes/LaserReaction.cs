using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReaction : MonoBehaviour {

	VirusStats stats;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "good_laser") {
			stats.hp -= 10;
		}
	}

	// Use this for initialization
	void Start () {
		stats = GetComponentInParent<VirusStats> ();
	}

}
