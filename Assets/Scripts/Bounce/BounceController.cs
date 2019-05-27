using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceController : MonoBehaviour {

	public float bpm; 
	public float acceleration = 1f; 
	public float initialPush = 1f;
	float startY;
	float verticalVelocity;
	float beatDuration = 1f;
	float nextBeatTime;
	float lastBeatTime;
	float targetHeight;
	bool up = true;
	float normalY;
	float targetY;
	Collider2D noteCollider;
	public GlobalData globalData;
	private SphereHolderScript holderScript;
	
	void Start () {
		normalY = transform.position.y;
		startY = normalY;
		targetY = startY;
		acceleration = GetGravity(3f); // Need to sort? 
		initialPush = GetInitialPush(0f);
		beatDuration = 60f/globalData.bPM; 
		holderScript = GetComponentInParent<SphereHolderScript>();
	}
	
	void Update () {
		float transformY;
		transformY = startY + GetDisplacement(Mathf.InverseLerp(lastBeatTime, nextBeatTime, Time.time)); 
		transform.position = new Vector3(transform.position.x, transformY, transform.position.z);
		if(Time.time >= nextBeatTime){
			lastBeatTime = nextBeatTime;
			nextBeatTime = lastBeatTime + beatDuration;
			startY = targetY;
			float bounceCheck = holderScript.getBounceHeight();
			if(bounceCheck > targetY){
				targetY = bounceCheck + (transform.localScale.x / 2f);
			}else{
				targetY = normalY;
			}
			initialPush = GetInitialPush(targetY - startY);
		}
	}

	float GetGravity(float bounceHeight){
		return -(8f * bounceHeight) / (beatDuration * beatDuration);
	}

	float GetDisplacement(float t){
		return (initialPush * t) + (0.5f * acceleration * t * t);
	}
	float GetInitialPush(float heightDifference){ // This is not right? 
		return heightDifference - (acceleration / 2f);
	}

}
