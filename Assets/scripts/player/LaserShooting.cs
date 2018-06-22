using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooting : MonoBehaviour {

	[SerializeField]
	GameObject laser;
	[SerializeField]
	GameObject virusLaser;
	AIFieldOfView fov;
	Vector3 position;

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "virus") {
			fov = GetComponent<AIFieldOfView> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Vector3.zero;
		if(Input.touchCount == 1)
		screenPos = Camera.main.ScreenToViewportPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f));
		//screenPos = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
		else if(Input.touchCount > 1)
			screenPos = Camera.main.ScreenToViewportPoint(new Vector3(Input.GetTouch(1).position.x, Input.GetTouch(1).position.y, 0f));
        
		position = gameObject.transform.position;
		if (gameObject.tag == "Player") {
			if ((screenPos.x > 280f / Screen.width | screenPos.y > 280f / Screen.height) & Input.touchCount == 1) {
				Debug.Log ("strzelam");
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					Object.Instantiate (laser, position, Quaternion.identity, gameObject.transform.parent);
				}
			} else if (Input.touchCount > 1) {
				if (Input.GetTouch (1).phase == TouchPhase.Began & (screenPos.x > 280f / Screen.width | screenPos.y > 280f / Screen.height)) {
					Object.Instantiate (laser, position, Quaternion.identity, gameObject.transform.parent);
				}
			}
		}else {
			if (fov.canSeePlayer ()) {
				int rand = Random.Range (0, 40);
				if (rand == 3)
					Object.Instantiate (virusLaser, position, Quaternion.identity, gameObject.transform.parent);
			}
		}
	}
		
}
