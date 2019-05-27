using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereHolderScript : MonoBehaviour {

	public Vector3 nextBounceHeight;

	private void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "Note"){
				NoteScript nS = col.GetComponent<NoteScript>();
				nextBounceHeight = nS.getHighestPoint(); // this shit works (Sort of!)
		}
	}
	
	public float getBounceHeight(){
		float y = nextBounceHeight.y;
		nextBounceHeight = Vector3.zero;
		return y;
	}
}
