using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour, IObjectBehaviour {

	protected float speed = 1.5f; //setting value for initial testing. 

    public virtual void Move(){
		transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
	}
	public virtual void Kill(){
		Destroy(gameObject);
	}
	public virtual void Start () {
		
	}
	
	
	public virtual void Update () {
		Move();
	}
}
