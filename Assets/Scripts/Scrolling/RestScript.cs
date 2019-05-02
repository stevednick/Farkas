using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestScript : MovingObject {

	public override void Start(){
		base.Start();
		gameObject.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 1);
	}
}
