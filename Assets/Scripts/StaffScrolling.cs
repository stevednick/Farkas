using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScrolling : MonoBehaviour {

	private ScrollingController controller;
	[SerializeField]
	private GameObject scrollNotePrefab;
	[SerializeField]
	private GameObject linePrefab; //yes
	[SerializeField]
	private float lineLength; //yes
	[SerializeField]
	private float lineWidth; //yes (does this all need to be in globalData?)
	private GameObject line0;
	private GameObject line1;
	private GameObject line2;
	private GameObject line3;
	private GameObject line4;

	void Start () {
		controller = GetComponent<ScrollingController>();
		GenerateStaff();
	}

	private void Update() {
		if(Input.GetKeyDown("down")){
		string acc = "";
		acc = Random.Range(0, 2) == 1 ? "sharp": "";
		acc = Random.Range(0, 2) == 1 ? "flat": acc;
		GameObject note = Instantiate(scrollNotePrefab, new Vector3(20, 0, 0), Quaternion.identity);
		NoteScript noteScript = note.GetComponent<NoteScript>();
		noteScript.NoteStartup(Random.Range(-8, 8), acc, 10);
		}

	}
	void DrawLines(){ // Tidy this bugger up! 
		line0 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap * 2, 0), transform.rotation);
		line1 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap, 0), transform.rotation);
		line2 = Instantiate(linePrefab, transform.position, transform.rotation);
		line3 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap, 0), transform.rotation);
		line4 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap * 2, 0), transform.rotation);
		line0.transform.localScale = new Vector3(lineLength, lineWidth, 1);
		line1.transform.localScale = new Vector3(lineLength, lineWidth, 1);
		line2.transform.localScale = new Vector3(lineLength, lineWidth, 1);
		line3.transform.localScale = new Vector3(lineLength, lineWidth, 1);
		line4.transform.localScale = new Vector3(lineLength, lineWidth, 1);
		line0.transform.parent = transform;
		line1.transform.parent = transform;
		line2.transform.parent = transform;
		line3.transform.parent = transform;
		line4.transform.parent = transform;
	}

	public void GenerateStaff(){ //Lots of this can go. 
		

		int childs = transform.childCount;
 		for (int i = childs - 1; i >= 0; i--)
 		{
     		GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
 		}		
		DrawLines();

	}




	
}


