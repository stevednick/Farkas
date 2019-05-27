using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSceneControl : MonoBehaviour {
	private StaffBuilder staffBuilder;
	private BarBuilder barBuilder;
	private ColourController colourController;
	private float nextBarTime = 0f;
	private float nextBeat = 0f;
	private float barDuration;
	private GlobalData globalData;
	public Camera mainCamera;
	public Camera UICamera; 
	public Material[] itemMaterials;
	public GameObject flashCamera;
	private CameraFlash cameraFlash;
	private FlashController flashController;


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
		cameraFlash = flashCamera.GetComponent<CameraFlash>();
		flashController = GetComponent<FlashController>();

	}

	void Awake()
	{
		nextBarTime = Time.time;
		nextBeat = Time.time;
	}
	
	 	void Update () {
		if(Time.time > nextBarTime){
			nextBarTime = nextBarTime + FindBarDuration();
			barBuilder.BuildBar();
		}
		if(Time.time > nextBeat){
			//flashController.StartFlash(5);
			nextBeat = nextBeat + FindBarDuration()/4f; 
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
