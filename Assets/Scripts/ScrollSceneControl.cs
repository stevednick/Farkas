using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSceneControl : MonoBehaviour {

	private ColourController colourController;
	private StaffScrolling staff;
	void Start () {
		colourController = GetComponent<ColourController>();
		colourController.SortColours();
		staff = GetComponent<StaffScrolling>();
		staff.GenerateStaff();
	}
	
	
	void Update () {
		
	}
}
