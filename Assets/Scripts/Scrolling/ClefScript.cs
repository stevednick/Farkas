using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClefScript : MovingObject {

	public GameObject trebleClef;
	public GameObject altoClef;
	public GameObject tenorClef;
	public GameObject bassClef;
	private bool moving = true;
	public override void Start(){
		base.Start();
		gameObject.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 1);
	}
	public void ShowClef(string clef){
		trebleClef.transform.gameObject.SetActive(clef == "Treble");
		bassClef.transform.gameObject.SetActive(clef == "Bass");
		tenorClef.transform.gameObject.SetActive(clef == "Tenor");
		altoClef.transform.gameObject.SetActive(clef == "Alto");
	}
	public override void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "ClefCollider"){
			speed = 0;
			moving = false;
		}
		if(col.tag == "Clef"){
			if(!moving){
				moving = true;
				StartCoroutine(Fade(1.2f / GetSpeed()));
			}
		}
	}
}
