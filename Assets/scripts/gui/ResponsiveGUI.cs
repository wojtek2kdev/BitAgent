using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveGUI : MonoBehaviour {

	public RectTransform arrows;
	
	// Update is called once per frame
	void Update () {
		/*arrows[0].anchoredPosition = new Vector2 (-Screen.width/2 + 150f, -Screen.height/2  + 250);
		arrows[1].anchoredPosition = new Vector2 (-Screen.width/2 + 150f, -Screen.height/2 + 50f);
		arrows[2].anchoredPosition = new Vector2 (-Screen.width/2 + 50f, -Screen.height/2 + 150f);
		arrows[3].anchoredPosition = new Vector2 (-Screen.width/2 + 250f, -Screen.height/2 + 150f);*/
		arrows.anchoredPosition = new Vector2 (-Screen.width / 2 + 140f, -Screen.height / 2 + 140f);
	}
}
