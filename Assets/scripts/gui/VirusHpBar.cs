using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusHpBar : MonoBehaviour {

	Vector3 viruspos;
	RectTransform t;
	float scalex;
	float scaley;
	Slider slide;
	int virusMaxHp, lasthp;
	VirusStats virus;
	Image fill;

	void Start(){
		t = GetComponent<RectTransform> ();
		slide = GetComponent<Slider> ();
		virus = GameObject.Find ("virus (" + gameObject.name.Replace ("hpvirus", "") + ")").GetComponent<VirusStats>();
		virusMaxHp = virus.maxHp;
		lasthp = virusMaxHp;
		fill = GameObject.Find (gameObject.name + "/Fill Area/Fill").GetComponent<Image> ();
		StartCoroutine (hideHpBar ());
	}

	// Update is called once per frame
	void Update () {
		if (lasthp != virus.hp) {
			StopCoroutine (hideHpBar());
			foreach (Image i in GetComponentsInChildren<Image>()) {
				i.enabled = true;
			}
			StartCoroutine (hideHpBar());
		}
		viruspos = virus.transform.position;
		//scalex = 475f/(Screen.width/2f);
		scalex = Screen.width / 1040f;
		scaley = Screen.height / 520f;
		//Debug.Log (Camera.main.WorldToScreenPoint (viruspos).y);
		//t.anchoredPosition = new Vector2 (-475f + (Camera.main.WorldToScreenPoint (viruspos).x * scalex), -220f * scaley + ((Screen.height/2f)/((Screen.height/2f)/Camera.main.WorldToScreenPoint(viruspos).y)));
		t.anchoredPosition = new Vector2 ((-520f * scalex) + (Camera.main.WorldToScreenPoint (viruspos).x), -220f * scaley + ((Screen.height/2f)/((Screen.height/2f)/Camera.main.WorldToScreenPoint(viruspos).y)));
		slide.value = (float)virus.hp / virusMaxHp;
		lasthp = virus.hp;
		if((float)virus.hp/(float)virusMaxHp >= 0.5f)
			fill.color = new Color (2f - (((float)virus.hp/(float)virusMaxHp) * 2f), 1f, 0f, 1f);
		else
			fill.color = new Color (1f, 0f + (((float)virus.hp/(float)virusMaxHp) *2f), 0f, 1f);
		if (virus.hp <= 0f) {
			Destroy (gameObject);
		}
	}

	IEnumerator hideHpBar(){
		yield return new WaitForSecondsRealtime (5f);
		foreach (Image i in GetComponentsInChildren<Image>()) {
			i.enabled = false;
		}
	}
		
}
