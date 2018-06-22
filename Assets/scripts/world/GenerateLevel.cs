using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour {

	[SerializeField]
	GameObject sector;
	[SerializeField]
	GameObject border;
	[SerializeField]
	GameObject infectedSector;
	[SerializeField]
	GameObject Virus;
	[SerializeField]
	GameObject armouredVirus;
	[SerializeField]
	GameObject bombVirus;
	[SerializeField]
	GameObject bacteriaBig;
	[SerializeField]
	GameObject bacteriaMid;
	[SerializeField]
	GameObject bacteriaSmall;
	[SerializeField]
	GameObject file;
	[SerializeField]
	GameObject lockFile;

	Vector3 block_Pos;
	public int a;
    List<Vector3>positions = new List<Vector3>(); 

	// Use this for initialization
	void Start () {
		generateBorder ();
		for(int i=0; i<a*2+2; i++)
		generateRandomElement ();
		//AIMovement.setSectors (positions);
		spawnViruses ();
		VirusesCanSeeControl.setObjects (GameObject.FindGameObjectsWithTag ("virus"));
		VirusesHpBarsControl v = GameObject.Find ("GamePlayGUI").GetComponent<VirusesHpBarsControl> ();
		v.setHpBars (a / 2 );
	}

	void generateBorder(){
		if (a < 2)
			a = 2;
		for (int i = 0; i < a*8; i++) {
			if (i >= 0 & i < a) {
				block_Pos = new Vector3 (-1f * a, i,0f);
			} else if (i >= a & i < a*2) {
				block_Pos = new Vector3 (i - a*2, a,0f);
			}else if (i >= a*2 & i < a*3) {
				block_Pos = new Vector3 (i - a*2, a,0f);
			}else if (i >= a*3 & i < a*4) {
				block_Pos = new Vector3 (a, a*4 - i,0f);
			}else if (i >= a*4 & i < a*5) {
				block_Pos = new Vector3 (a, a*4 - i,0f);
			}else if (i >= a*5 & i < a*6) {
				block_Pos = new Vector3 (a*6 - i, -1 * a,0f);
			}else if (i >= a*6 & i < a*7) {
				block_Pos = new Vector3 (a*6 - i, -1f * a,0f);
			}else if (i >= a*7 & i < a*8) {
				block_Pos = new Vector3 (-1f * a, -1f * (a*8 - i),0f);
			}
			Object.Instantiate (border, block_Pos, new Quaternion(0f,0f,0f,0f), gameObject.transform);
		}
	}

	void generateRandomElement(){
		int x = Random.Range ((-1 * a) + 1, a - 1);
		int y = Random.Range ((-1 * a) + 1, a - 1);
		Vector3 v = new Vector3 (x, y, 0f);
		if(emptyPosition(v)){
			Object.Instantiate (sector, v, new Quaternion (0f, 0f, 0f, 0f), gameObject.transform);
			positions.Add (v);
		}else{
				generateRandomElement();		
		}
	}

	bool emptyPosition(Vector3 v){
		foreach (Vector3 pos in positions) {
			if (pos == v | new Vector3(pos.x +1, pos.y + 1, 0) == v |
				new Vector3(pos.x - 1, pos.y + 1, 0) == v | 
				new Vector3(pos.x +1, pos.y - 1, 0) == v |
				new Vector3(pos.x - 1, pos.y - 1, 0) == v |
				v == Vector3.zero)
				return false;
		}
		return true;
	}

	void spawnViruses(){
		Vector3 v = Vector3.zero;
		for (int i = 0; i < a / 2; i++) {
			bool same = true;
			while (same) {
				v = new Vector3 (Random.Range (-a / 2, a / 2), Random.Range (-a / 2, a / 2), 0f);
				same = false;
				foreach (Vector3 v1 in positions) {
					if (v1 == v)
						same = true;
				}
			}
			GameObject g = GameObject.Instantiate (Virus, v, Quaternion.identity);
			g.name = "virus (" + i + ")";
			g.transform.parent = gameObject.transform;
		}
	}

}
