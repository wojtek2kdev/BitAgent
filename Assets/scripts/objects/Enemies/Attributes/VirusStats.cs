using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusStats : MonoBehaviour {

	public int maxHp = 100;
	public int hp = 100;

	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
}
