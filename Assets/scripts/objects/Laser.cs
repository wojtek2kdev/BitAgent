using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	protected Rigidbody2D rbody; //to
	Ray mousePos;
	protected Vector3 pos; // to
	protected float x,y,targetX,targetY,objectX,objectY;
	[SerializeField]
	protected GameObject laserSound;
	protected Vector3 playerPos;
	protected Vector2 move;
	protected Vector3 mouseHit;
	protected int speedMultiper = 9;
	enum Quarter{
		q1,q2,q3,q4
	}

	void Start(){
		StartCoroutine (destroyLaser ());
		/*mousePos = Camera.main.ScreenPointToRay (Input.mousePosition);
		mouseHit = Camera.main.ScreenToWorldPoint (Input.mousePosition);*/
		if (Input.touchCount == 1) {
			mousePos = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
			mouseHit = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
		} else if (Input.touchCount > 1) {
			mousePos = Camera.main.ScreenPointToRay (Input.GetTouch (1).position);
			mouseHit = Camera.main.ScreenToWorldPoint (Input.GetTouch (1).position);
		}
		playerPos = GameObject.Find ("antivirus").transform.localPosition;
		Vector2 m = new Vector2 (mouseHit.x - (mouseHit.x % 0.1f), mouseHit.y - (mouseHit.y % 0.1f));
		Vector2 p = new Vector2 (playerPos.x, playerPos.y);
		if (Vector2.Distance(m,p) < 0.1f) {
			Destroy (gameObject);
		} else {
			rbody = GetComponent<Rigidbody2D> ();
			pos = gameObject.transform.position;
			Object.Instantiate (laserSound, Vector3.zero, new Quaternion (0f, 0f, 0f, 0f), gameObject.transform.parent);
			x = mousePos.origin.x - pos.x;
			y = mousePos.origin.y - pos.y;
			targetX = mousePos.origin.x;
			targetY = mousePos.origin.y;
			objectX = playerPos.x;
			objectY = playerPos.y;
			move = new Vector2 (x, y);
			if (Vector2.Distance (new Vector2 (targetX, targetY), new Vector2 (objectX, objectY)) < speedMultiper) {
				move = GetExpectedSpeed ();
			}
		}
	}

	protected IEnumerator destroyLaser(){
		yield return new WaitForSecondsRealtime (5);
		Destroy (gameObject);
	}

	protected void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "sector" | other.tag == "border")
			Destroy (gameObject);
	}

	protected void Update(){

		rbody.MovePosition (rbody.position +  move * Time.deltaTime);
	}

	protected Vector2 GetExpectedSpeed(){
		Vector2 speed = Vector2.zero;
		int quarter = 1;
		Quarter q = Quarter.q1;
		float y1=1, x1=0;
		//Vector2 v = new Vector2(playerPos.x, playerPos.y) - new Vector2(mousePos.origin.x,mousePos.origin.y);
		if (x > 0f & y >= 0f) {
			//quarter = 1;
			q = Quarter.q1;
		}else if(x < 0f & y >= 0f){
			//quarter = 2;
			q = Quarter.q2;
		}else if(x < 0f & y <= 0f){
			//quarter = 3;
			q = Quarter.q3;
		}else if(x > 0f & y <= 0f){
			//quarter = 4;
			q = Quarter.q4;
		}
		switch (q) {
		case Quarter.q1:
			if (x / y < 1f) {
				y1 = speedMultiper;
				x1 = y1 * (x / y);
			} else {
				x1 = speedMultiper;
				y1 = x1 / (x / y);
			}
			break;
		case Quarter.q2:
			if (x / y > -1f) {
				y1 = speedMultiper;
				x1 = y1 * (x / y);
			} else {
				x1 = -speedMultiper;
				y1 = x1 / (x / y);
			}
			break;
		case Quarter.q3:
			if (x / y < 1f) {
				y1 = -speedMultiper;
				x1 = y1 * (x / y);
			} else {
				x1 = -speedMultiper;
				y1 = x1 / (x / y);
			}
			break;
		case Quarter.q4:
			if (x / y > -1f) {
				y1 = -speedMultiper;
				x1 = y1 * (x / y);
			} else {
				x1 = speedMultiper;
				y1 = x1 / (x / y);
			}
			break;
		}
		speed = new Vector2 (x1, y1);
		return speed;
	}
}
