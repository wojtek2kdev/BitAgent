using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFieldOfView : MonoBehaviour {

	EdgeCollider2D c;
	Vector3 playerPos;
	List<Vector2> points = new List<Vector2> ();
	public bool canSee = true;

	// Use this for initialization
	void Start () {
		c = GetComponent<EdgeCollider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "sector") {
			canSee = false;
		} 
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "sector") {
			canSee = false;
		} 
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "sector") {
			canSee = true;
		} 
	}

	// Update is called once per frame
	void Update () {
		points.Clear ();
		points.Add (new Vector2 (0f, 0f));
		playerPos = GameObject.Find ("antivirus").transform.position;
		points.Add (new Vector2 ((playerPos.x - gameObject.transform.position.x)/0.9f, (playerPos.y - gameObject.transform.position.y)/0.9f));
		c.points = points.ToArray ();
	}

	public bool canSeePlayer(){
		return canSee;
	}
}
