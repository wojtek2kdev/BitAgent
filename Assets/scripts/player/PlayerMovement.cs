using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement :  MonoBehaviour {

	Rigidbody2D rbody;
	bool up, down, left, right;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		gameObject.SetActive (true);
		rbody = GetComponent<Rigidbody2D> ();
		EventTrigger e = GetComponent<EventTrigger> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "laser") {
			Destroy (other.gameObject);
		}
	}
		
	
	// Update is called once per frame
	public void Update () {
			if (up)
				goUp ();
			else if (down)
				goDown ();
			else if (left)
				goLeft ();
			else if (right)
				goRight ();
	}

	public void goUp(){
		up = true;
		Vector2 move = new Vector2 (0F, 1F);
		rbody.MovePosition (rbody.position + move * 5f * Time.deltaTime);
	}

	public void goDown(){
		down = true;
		Vector2 move = new Vector2 (0F, -1F);
		rbody.MovePosition (rbody.position + move * 5f * Time.deltaTime);
	}

	public void goLeft(){
		left = true;
		Vector2 move = new Vector2 (-1F, 0F);
		rbody.MovePosition (rbody.position + move * 5f * Time.deltaTime);
	}

	public void goRight(){
		right = true;
		Vector2 move = new Vector2 (1F, 0F);
		rbody.MovePosition (rbody.position + move * 5f * Time.deltaTime);
	}

	public void stopMoving(){
		up = false;
		down = false;
		left = false;
		right = false;
	}
		
}
