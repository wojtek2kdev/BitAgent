using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO wykrywanie dwoch ostatnich wektorow po zniknieciu
//TODO chowanie sie za bloczkiem
//TODO wychylanie 
//TODO podazanie za graczem i utrzymywanie odpowiedniej odleglosci


public class AIMovement : MonoBehaviour {

	Rigidbody2D rbody;
	Vector3 pos;
	Vector2 move;
	Vector3 playerPos;
	Vector2 sector;
	float x,y;
	//static List<Vector3> sectors = new List<Vector3>();
	//AIFieldOfView fov;
	//Vector2[] twoLastPos = new Vector2[2]; // do playera
	TargetJoint2D target;
	//public bool Moving;
	//Vector2 collisionPoint;
	//Vector2 lastSector;
	bool getNewTarget = true;
	Vector2 collisionW, collisionE, collisionN, collisionS;


	void OnCollisionEnter2D(Collision2D other){

	}
		

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		target = GetComponent<TargetJoint2D> ();
		x = Random.Range (-1, 2);
		y = Random.Range (-1, 2);
		if (x != 0 & y != 0)
			x = 0;
		target.target = new Vector2 (pos.x + x, pos.y + y);
	}
	
	// Update is called once per frame
	void Update () {
		if (getNewTarget)
			StartCoroutine (chooseNewTarget ());
		playerPos = GameObject.Find ("antivirus").transform.position;
		pos = gameObject.transform.position;
		target.target = new Vector2 (pos.x + x, pos.y + y);
	}		

	IEnumerator chooseNewTarget(){
		getNewTarget = false;
		yield return new WaitForSecondsRealtime (Random.Range (2, 4));
		getNewTarget = true;
		newTarget ();
	}

	public void Move(Vector2 v){
		rbody.MovePosition (rbody.position + v * 4f * Time.deltaTime);
	}

	public void newTarget(){
		int option = Random.Range (0, 3);
		if (x == -1) {
			switch (option) {
			case 0:
				x = 1f;
				y = 0f;
				break;
			case 1:
				x = 0f;
				y = 1f;
				break;
			case 2:
				x = 0f;
				y = -1f;
				break;
			}
		} else if (x == 1) {
			switch (option) {
			case 0:
				x = -1f;
				y = 0f;
				break;
			case 1:
				x = 0f;
				y = 1f;
				break;
			case 2:
				x = 0f;
				y = -1f;
				break;
			}
		} else if (y == -1) {
			switch (option) {
			case 0:
				x = -1f;
				y = 0f;
				break;
			case 1:
				x = 1f;
				y = 0f;
				break;
			case 2:
				x = 0f;
				y = 1f;
				break;
			}
		} else {
			switch (option) {
			case 0:
				x = -1f;
				y = 0f;
				break;
			case 1:
				x = 1f;
				y = 0f;
				break;
			case 2:
				x = 0f;
				y = -1f;
				break;
			}
		}
	}
		
}
