using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour {

	[SerializeField]
	private GameObject linePrefab;
	[SerializeField]
	private float lineLength;
	[SerializeField]
	private float lineWidth;
	[SerializeField]
	private float lineGap;
	private GameObject line0;
	private GameObject line1;
	private GameObject line2;
	private GameObject line3;
	private GameObject line4;

	[SerializeField]
	private float ledgerLength;
	private GameObject T1;
	private GameObject T2;
	private GameObject T3;
	private GameObject T4;
	private GameObject B1;
	private GameObject B2;
	private GameObject B3;
	private GameObject B4;

	[SerializeField]
	private float noteX;
	[SerializeField]
	private float clefX;
	[SerializeField]
	private GameObject trebleClefPrefab;
	[SerializeField]
	private GameObject bassClefPrefab;
	[SerializeField]
	private GameObject altoClefPrefab;
	[SerializeField]
	private GameObject tenorClefPrefab;
	private GameObject trebleClef;
	private GameObject bassClef;
	private GameObject altoClef;
	private GameObject tenorClef;
	[SerializeField]
	private GameObject notePrefab;
	private GameObject currentNote;
	[SerializeField]
	private Material noteMaterial;
	[SerializeField]
	void Start () {
		GenerateStaff();
	}
	void DrawLines(){
		line0 = Instantiate(linePrefab, transform.position + new Vector3(0, -lineGap * 2, 0), transform.rotation);
		line1 = Instantiate(linePrefab, transform.position + new Vector3(0, -lineGap, 0), transform.rotation);
		line2 = Instantiate(linePrefab, transform.position, transform.rotation);
		line3 = Instantiate(linePrefab, transform.position + new Vector3(0, lineGap, 0), transform.rotation);
		line4 = Instantiate(linePrefab, transform.position + new Vector3(0, lineGap * 2, 0), transform.rotation);
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
	void InstantiateLedgerLines(){
		T1 = Instantiate(linePrefab, transform.position + new Vector3(noteX, lineGap * 3, 0), transform.rotation);
		T1.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		T1.transform.gameObject.SetActive(false);
		T1.transform.parent = transform;
		T1.GetComponent<Renderer>().material = noteMaterial;
		T2 = Instantiate(linePrefab, transform.position + new Vector3(noteX, lineGap * 4, 0), transform.rotation);
		T2.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		T2.transform.gameObject.SetActive(false);
		T2.transform.parent = transform;
		T2.GetComponent<Renderer>().material = noteMaterial;
		T3 = Instantiate(linePrefab, transform.position + new Vector3(noteX, lineGap * 5, 0), transform.rotation);
		T3.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		T3.transform.gameObject.SetActive(false);
		T3.transform.parent = transform;
		T3.GetComponent<Renderer>().material = noteMaterial;
		T4 = Instantiate(linePrefab, transform.position + new Vector3(noteX, lineGap * 6, 0), transform.rotation);
		T4.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		T4.transform.gameObject.SetActive(false);
		T4.transform.parent = transform;
		T4.GetComponent<Renderer>().material = noteMaterial;
		B1 = Instantiate(linePrefab, transform.position + new Vector3(noteX, -lineGap * 3, 0), transform.rotation);
		B1.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		B1.transform.gameObject.SetActive(false);
		B1.transform.parent = transform;
		B1.GetComponent<Renderer>().material = noteMaterial;
		B2 = Instantiate(linePrefab, transform.position + new Vector3(noteX, -lineGap * 4, 0), transform.rotation);
		B2.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		B2.transform.gameObject.SetActive(false);
		B2.transform.parent = transform;
		B2.GetComponent<Renderer>().material = noteMaterial;
		B3 = Instantiate(linePrefab, transform.position + new Vector3(noteX, -lineGap * 5, 0), transform.rotation);
		B3.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		B3.transform.gameObject.SetActive(false);
		B3.transform.parent = transform;
		B3.GetComponent<Renderer>().material = noteMaterial;
		B4 = Instantiate(linePrefab, transform.position + new Vector3(noteX, -lineGap * 6, 0), transform.rotation);
		B4.transform.localScale = new Vector3(ledgerLength, lineWidth, 1);
		B4.transform.gameObject.SetActive(false);
		B4.transform.parent = transform;
		B4.GetComponent<Renderer>().material = noteMaterial;
	}
	public void GenerateStaff(){
		

		int childs = transform.childCount;
 		for (int i = childs - 1; i >= 0; i--)
 		{
     		GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
 		}		
		DrawLines();
		InstantiateLedgerLines();
		GenerateClefs();	
	}

	private void GenerateClefs(){
		DestroyImmediate(trebleClef);
		DestroyImmediate(bassClef);
		DestroyImmediate(altoClef);
		DestroyImmediate(tenorClef);
		trebleClef = Instantiate(trebleClefPrefab, transform.position + new Vector3(clefX, 0, 0), transform.rotation);
		trebleClef.transform.localScale = new Vector3(lineGap, lineGap, 1);
		bassClef = Instantiate(bassClefPrefab, transform.position + new Vector3(clefX, 0, 0), transform.rotation);
		bassClef.transform.localScale = new Vector3(lineGap, lineGap, 1);
		altoClef = Instantiate(altoClefPrefab, transform.position + new Vector3(clefX, 0, 0), transform.rotation);
		altoClef.transform.localScale = new Vector3(lineGap, lineGap, 1);
		tenorClef = Instantiate(tenorClefPrefab, transform.position + new Vector3(clefX, 0, 0), transform.rotation);
		tenorClef.transform.localScale = new Vector3(lineGap, lineGap, 1);
		trebleClef.transform.parent = transform;
		bassClef.transform.parent = transform;
		altoClef.transform.parent = transform;
		tenorClef.transform.parent = transform;
	}

	public void ShowClef(string clef){
		trebleClef.transform.gameObject.SetActive(clef == "Treble");
		bassClef.transform.gameObject.SetActive(clef == "Bass");
		tenorClef.transform.gameObject.SetActive(clef == "Tenor");
		altoClef.transform.gameObject.SetActive(clef == "Alto");
	}
	public void ShowNote(int pos, bool sharp, bool flat, string clef){  //this is the important bit! 
		DestroyImmediate(currentNote);
		currentNote = Instantiate(notePrefab, transform.position + new Vector3(noteX, lineGap * pos/2, 0), transform.rotation);			
		currentNote.transform.localScale = new Vector3(lineGap, lineGap, 1);
		currentNote.transform.Find("Sharp").gameObject.SetActive(sharp);
		currentNote.transform.Find("Flat").gameObject.SetActive(flat);
		currentNote.transform.Find("Crotchet").gameObject.SetActive(pos <= 0);
		currentNote.transform.Find("InvertedCrotchet").gameObject.SetActive(pos >= 1);
		currentNote.transform.parent = transform;
		ShowClef(clef);
		AddLedgerLines(pos);
	}
	private void AddLedgerLines(int pos){
		T1.transform.gameObject.SetActive(pos >= 6);
		T2.transform.gameObject.SetActive(pos >= 8);
		T3.transform.gameObject.SetActive(pos >= 10);
		T4.transform.gameObject.SetActive(pos >= 12);
		B1.transform.gameObject.SetActive(pos <= -6);
		B2.transform.gameObject.SetActive(pos <= -8);
		B3.transform.gameObject.SetActive(pos <= -10);
		B4.transform.gameObject.SetActive(pos <= -12);
	}	
}

