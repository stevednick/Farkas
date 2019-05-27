using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour, IObjectBehaviour {

	protected float speed; 

    public virtual void Move(){
		transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
	}
	public virtual void Kill(){
		Destroy(gameObject);
	}

	public IEnumerator Fade(float duration){ //How the heck do we do this? 
		float start = Time.time;
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		Color startColour = gameObject.GetComponentInChildren<Renderer>().material.color;
		Color targetColour = FindObjectOfType<Camera>().backgroundColor;
		while(Time.time <= start + duration){
			Color colour = Color.Lerp(startColour, targetColour, (Time.time-start)/duration);
			foreach(Renderer renderer in renderers){
				renderer.material.color = colour;
			}
			yield return 0;
		}
		Destroy(gameObject);
	}
	public virtual void Start () {
		speed = GetSpeed();
	}
	
	
	public virtual void Update () {
		Move();
	}

	protected float GetSpeed(){
		float bPM = (float)PlayerPrefs.GetInt("bPM");
		return bPM / 60f * BarLayouts.beatSpacing;
	}

	public virtual void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "ObjectKillCollider"){
			StartCoroutine(Fade(0.9f / speed));
		}
	}
}
