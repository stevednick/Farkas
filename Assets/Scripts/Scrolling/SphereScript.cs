using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MovingObject {

	public override void Start(){
		speed = 6f;
	}
	public override void Update(){
		Move();
		if(transform.position.x < - 20){
			Kill();
		}
	}

}
