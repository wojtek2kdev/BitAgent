using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusesCanSeeControl : MonoBehaviour {

	static GameObject[] viruses;

	// Update is called once per frame
	void Update () {
		CanSee ();
	}

	void CanSee(){
		foreach (GameObject g in viruses) {
			Vector3 v = Camera.main.WorldToViewportPoint (g.transform.position);
			if (v.x < -0.2f | v.x > 1.2f | v.y < -0.2f | v.y > 1.2f) {
				g.GetComponent<AIFieldOfView> ().canSee = false;
			}
		}
	}

	public static void setObjects(GameObject[] v){
		viruses = v;
	}
}
