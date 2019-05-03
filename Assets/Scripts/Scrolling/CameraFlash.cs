using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlash : MonoBehaviour {

	private ColourController colourController;
	void Start () {
		colourController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ColourController>();
		gameObject.GetComponent<Camera>().backgroundColor = colourController.getBG();
	}

	public IEnumerator Flash(Color targetColour, float duration){
		float startTime = Time.time;
		gameObject.GetComponent<Camera>().backgroundColor = colourController.getItem();
		while(Time.time <= startTime + duration){
			yield return null;
		}
		gameObject.GetComponent<Camera>().backgroundColor = colourController.getBG();
	}


	
	

}
