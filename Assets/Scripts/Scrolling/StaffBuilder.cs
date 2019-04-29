using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBuilder : MonoBehaviour {
	[SerializeField]
	private GameObject linePrefab;
	[SerializeField]
	private float lineLength; //yes
	private GameObject line0;
	private GameObject line1;
	private GameObject line2;
	private GameObject line3;
	private GameObject line4;


	void DrawLines(){ // Tidy this bugger up! 
		line0 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap * 2, 0), transform.rotation);
		line1 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap, 0), transform.rotation);
		line2 = Instantiate(linePrefab, transform.position, transform.rotation);
		line3 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap, 0), transform.rotation);
		line4 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap * 2, 0), transform.rotation);
		line0.transform.localScale = new Vector3(lineLength, Tools.lineWidth, 1);
		line1.transform.localScale = new Vector3(lineLength, Tools.lineWidth, 1);
		line2.transform.localScale = new Vector3(lineLength, Tools.lineWidth, 1);
		line3.transform.localScale = new Vector3(lineLength, Tools.lineWidth, 1);
		line4.transform.localScale = new Vector3(lineLength, Tools.lineWidth, 1);
		line0.transform.parent = transform;
		line1.transform.parent = transform;
		line2.transform.parent = transform;
		line3.transform.parent = transform;
		line4.transform.parent = transform;
	}

	public void GenerateStaff(){ 
		

		int childs = transform.childCount;
 		for (int i = childs - 1; i >= 0; i--)
 		{
     		GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
 		}		
		DrawLines();

	}
}
