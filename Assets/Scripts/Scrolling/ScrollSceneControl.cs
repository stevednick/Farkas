using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSceneControl : MonoBehaviour {

	private float timeToNextBar = 2f;
	private float nextBarTime = 0f;
	 
	private StaffBuilder staffBuilder;
	private BarBuilder barBuilder;
	private ColourController colourController;
	//private StaffScrolling staff;
	void Start () {
		staffBuilder = GetComponent<StaffBuilder>();
		barBuilder = GetComponent<BarBuilder>();
		colourController = GetComponent<ColourController>();
		colourController.SortColours();
		//staff = GetComponent<StaffScrolling>();
		staffBuilder.GenerateStaff();
	}
	
	
	void Update () {
		if(Time.time > nextBarTime){
			nextBarTime = Time.time + timeToNextBar;
			barBuilder.BuildBar();
		}
	}
}
