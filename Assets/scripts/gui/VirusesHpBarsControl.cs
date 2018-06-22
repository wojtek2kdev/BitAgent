using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusesHpBarsControl : MonoBehaviour {

	int q;
	[SerializeField]
	GameObject hpbar;

	// Use this for initialization
	public void setHpBars(int q){
		this.q = q;
		for (int i = 0; i < q; i++) {
			GameObject g = Object.Instantiate (hpbar, GetComponent<Canvas>().transform);
			g.name = "hpvirus" + i;
		}
	}
}
