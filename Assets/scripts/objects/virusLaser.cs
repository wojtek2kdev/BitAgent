using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virusLaser : Laser {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyLaser ());
		playerPos = GameObject.Find ("antivirus").transform.localPosition;
		rbody = GetComponent<Rigidbody2D> ();
		pos = gameObject.transform.position;
		Object.Instantiate (laserSound, Vector3.zero, new Quaternion (0f, 0f, 0f, 0f), gameObject.transform.parent);
		x = playerPos.x - pos.x;
		y = playerPos.y - pos.y;
		targetX = playerPos.x;
		targetY = playerPos.y;
		objectX = pos.x;
		objectY = pos.y;
		move = new Vector2 (x, y);
		if (Mathf.Sqrt(Mathf.Pow(x,2) + Mathf.Pow(y,2)) < speedMultiper) {
			move = GetExpectedSpeed ();
		}
		move += new Vector2 (Random.Range(-2f, 2f), Random.Range(-2f,2f));

	}

}
