using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBuilder : MonoBehaviour {
	private GlobalData globalData;
	private NoteController noteController;
	public float startX;
	public GameObject spherePrefab;
	public GameObject barLinePrefab;
	public GameObject notePrefab;
	public GameObject crotchetRestPrefab;
	public GameObject minimRestPrefab;
	public GameObject clefPrefab;
	private string lastClef;
	private void Start() {
		globalData = GetComponent<GlobalData>();
		noteController = GetComponent<NoteController>();
	}
	public void BuildBar(){
		Tools.Note nextNote = NextNote();
		Dictionary<string, float> barToUse = nextNote.clef == lastClef ? BarLayouts.noClef : BarLayouts.clefAfterBarline;
		lastClef = nextNote.clef;
		float barWidth = BarLayouts.beatSpacing * BarLayouts.beatsPerBar;
		foreach(KeyValuePair<string, float> value in barToUse){
			if(value.Key == "BarLine"){
				GameObject barLine = Instantiate(barLinePrefab, transform.position + new Vector3(startX + (barWidth * value.Value), 0, 0), Quaternion.identity);
				barLine.transform.parent = transform;
				barLine.transform.localScale = new Vector3(Tools.lineWidth, Tools.lineGap * 4, 0.2f);	
			}
			if(value.Key == "Note"){
				GameObject note = Instantiate(notePrefab, transform.position + new Vector3(startX + (barWidth * value.Value), 0, 0), Quaternion.identity);
				note.transform.parent = transform;
				NoteScript noteScript = note.GetComponent<NoteScript>();
				string acc = "";
				if(nextNote.sharp == true) acc = "sharp";
				if(nextNote.flat == true) acc = "flat";
				noteScript.NoteStartup(nextNote.position, acc);
				
			}
			if(value.Key == "Clef"){ 	
				lastClef = nextNote.clef;
				GameObject clef = Instantiate(clefPrefab, transform.position + new Vector3(startX + (barWidth * value.Value), 0, 0), Quaternion.identity);
				clef.transform.parent = transform; 
				ClefScript clefScript = clef.GetComponent<ClefScript>();
				clefScript.ShowClef(nextNote.clef);
			}
			if(value.Key == "CRest"){
				GameObject crotchetRest = Instantiate(crotchetRestPrefab, transform.position + new Vector3(startX + (barWidth * value.Value), 0, 0), Quaternion.identity);
				crotchetRest.transform.parent = transform; 
			}
			if(value.Key == "MRest"){
				GameObject minimRest = Instantiate(minimRestPrefab, transform.position + new Vector3(startX + (barWidth * value.Value), 0, 0.5f), Quaternion.identity);
				minimRest.transform.parent = transform; 
			}	
		}
	}
		private Tools.Note NextNote(){
		int nextNoteNumber;
		int difficulty;
		nextNoteNumber = Random.Range(globalData.bottomNote, globalData.topNote + 1);
		difficulty = Random.Range(0, globalData.noteDifficulty + 1);
		return noteController.GetNextNote(nextNoteNumber, difficulty);
	}
}
