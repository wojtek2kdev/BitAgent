using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBypassCollide : MonoBehaviour {

	public bool isTriggering;
	bool wNotFree, eNotFree, nNotFree, sNotFree;
	AIMovement parent;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "sector")
			isTriggering = true;
		else if (other.tag == "border") {
			parent.newTarget ();
		}
	}
		
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "sector")
		isTriggering = false;
	}

	void Start(){
		parent = GetComponentInParent<AIMovement> ();
	}
		
	// Update is called once per frame
	void Update () {
		checkCollision ();
		bypassCollision ();
	//	Debug.Log (eNotFree + " " + wNotFree + " " + nNotFree + " " + sNotFree);
	}

	void checkCollision(){
		string[] objects = { "west", "east", "north", "south" };
		foreach (string name in objects) {
				bool t = GameObject.Find (name).GetComponent<AIBypassCollide> ().isTriggering;
				switch (name) {
				case "west":
					wNotFree = t;
					break;
				case "east": 
					eNotFree = t;
					break;
				case "south":
					sNotFree = t;
					break;
				case "north":
					nNotFree = t;
					break;
				}
		}
}
	void bypassCollision(){
		Vector2 right = new Vector2 (1f, 0f);
		Vector2 down = new Vector2 (0f, -1f);
		float x = GetComponentInParent<TargetJoint2D>().target.x;
		float y = GetComponentInParent<TargetJoint2D>().target.y;
		Vector3 pos = gameObject.transform.parent.position;
		if (y - (y%0.01f) > pos.y - (pos.y % 0.01f) & nNotFree) {
			parent.Move (right);
		} else if (y - (y%0.01f) < pos.y - (pos.y % 0.01f) & sNotFree) {
			parent.Move (right);
		} else if (x - (x%0.01f) > pos.x - (pos.x % 0.01f) & eNotFree) {
			parent.Move (down);
		} else if(x - (x%0.01f) < pos.x - (pos.x % 0.01f) & wNotFree){
			parent.Move (down);
		}
	}
		
}
