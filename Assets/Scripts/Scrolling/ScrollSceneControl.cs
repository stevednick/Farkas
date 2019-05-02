using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSceneControl : MonoBehaviour {
	private StaffBuilder staffBuilder;
	private BarBuilder barBuilder;
	private ColourController colourController;
	private float nextBarTime = 0f;
	private float barDuration;
	private GlobalData globalData;
	public Camera mainCamera;
	public Camera UICamera; 
	public Material[] itemMaterials;


	void Start () {
		staffBuilder = GetComponent<StaffBuilder>();
		barBuilder = GetComponent<BarBuilder>();
		colourController = GetComponent<ColourController>();
		foreach(Material mat in itemMaterials){
			mat.color = colourController.getItem();
		}
		globalData = GetComponent<GlobalData>();
		colourController.SortColours();
		UICamera.backgroundColor = mainCamera.backgroundColor;
		staffBuilder.GenerateStaff();
	}
	
	
	void Update () {
		if(Time.time > nextBarTime){
			nextBarTime = Time.time + FindBarDuration();
			barBuilder.BuildBar();
		}
	}

	private float FindBarDuration(){
		float bPM = (float)globalData.bPM;
		return (60f/bPM ) * (float)BarLayouts.beatsPerBar ;
	}

	public void ToMenu(){
		StartCoroutine(colourController.SceneChange("Menu"));
	}

}
