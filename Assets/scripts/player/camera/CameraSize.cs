using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

	float size;

	// Update is called once per frame
	void Update () {
		size = Camera.main.orthographicSize;
		if (Input.GetAxisRaw ("Mouse ScrollWheel") < 0 & size < 20f) {
			Camera.main.orthographicSize += 0.5f;
		}else if (Input.GetAxisRaw ("Mouse ScrollWheel") > 0 & size > 4f) {
			Camera.main.orthographicSize -= 0.5f;
		}
	}
}
