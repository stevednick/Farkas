using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Controller : MonoBehaviour {

	private float nextNoteTime; 
	[SerializeField]
	private float noteDelay; // worked out from BPM
	[SerializeField]
	private GameObject staff;
	[SerializeField]
	private Text counter; //not shows ready and timings, should rename
	[SerializeField]
	private Text buttonText; 
	[SerializeField]
	private Text countInText;
	int currentBeat = 0;
	[SerializeField]
	private bool isPaused = false;
	[SerializeField]
	private Material staffMaterial;
	[SerializeField]
	private Material noteMaterial;
	[SerializeField]
	private Material clefMaterial;
	[SerializeField]
	private GameObject flash;
	[SerializeField]
	private Camera mainCamera;
	private Tools.Note nextNote;
	private Tools.Note lastNote;
	[SerializeField]
	private bool startup; //pauses update while starting up. 
	private float timeLeft; 
	[SerializeField]
	private bool displayTimer;  
	[SerializeField]
	private bool finished; //finishes up last bar after timer runs out. 
	private FlashController flashController;
	[SerializeField]
	private GlobalData globalData;
	[SerializeField]
	private ColourController colourController;
	[SerializeField]
	private NoteController noteController;
		
	private void Start() {

		flashController = GetComponent<FlashController>();
		noteController = GetComponent<NoteController>();
	}

	private void Awake() { // sort out the colour stuff? 
		timeLeft = globalData.duration > 60 ? 1000000 : globalData.duration * 10;
		noteDelay = 60f/ (float)globalData.bPM;
		lastNote = NextNote();
		nextNote = NextNote();
		staffMaterial.color = colourController.getItem();
		clefMaterial.color = colourController.getItem(); //fading alpha doesnt work?
		noteMaterial.color = colourController.getBG();
		mainCamera.backgroundColor = colourController.getBG();
		counter.color = colourController.getItem();
		counter.text = "";
		buttonText.color = colourController.getItem();
		countInText.color = colourController.getItem();
		countInText.text = "";
		flash.GetComponent<Renderer>().material.color = colourController.getItem();
		StartCoroutine(colourController.SceneChange(""));
		startup = true;
		finished = false;
		StartCoroutine(StartingUp());
	}
	
	void OnApplicationPause(bool pauseStatus){
		isPaused = pauseStatus;
	}

	private void OnApplicationFocus(bool focusStatus) {
		if(!finished) isPaused = !focusStatus;
		nextNoteTime = Time.time + noteDelay;
	}

	private IEnumerator StartingUp(){
		
		yield return null;
		staff.GetComponent<StaffScript>().ShowClef(nextNote.clef);
		yield return new WaitForSeconds(1); //to allow staffScript to wake up! 
		staff.GetComponent<StaffScript>().ShowNote(nextNote.position, nextNote.sharp, nextNote.flat, nextNote.clef);
		StartCoroutine(noteController.Fade(noteMaterial, clefMaterial, noteDelay, false, colourController.getItem()));
		yield return new WaitForSeconds(1);
		nextNoteTime = Time.time + noteDelay;
		currentBeat = 1;
		countInText.text = currentBeat.ToString();
		flashController.StartFlash(2);
		while(currentBeat <= 4){
			if(isPaused) nextNoteTime += Time.deltaTime;
			if(NextBeat()){
				
				currentBeat++;
				
				if(currentBeat <= 4){
					countInText.text = currentBeat.ToString();
					flashController.StartFlash(currentBeat);
				}

			}

			yield return null;
		}
		currentBeat = 1;
		startup = false;
		countInText.text = "Go!";
		lastNote = nextNote;
		nextNote = NextNote();
		flashController.StartFlash(currentBeat);
		StartCoroutine(noteController.Fade(noteMaterial, clefMaterial, noteDelay, nextNote.clef != lastNote.clef, colourController.getBG()));
		yield return new WaitForSeconds(2);
		countInText.text = "";
		if(timeLeft <= 600f) displayTimer = true;
	}

	void ShowTimer(){
		if(displayTimer && globalData.showTimer){
			string minuteText = (Mathf.Floor(timeLeft/60)).ToString();
			int seconds = (int) Mathf.Floor(timeLeft % 60);
			string secondText;
			if (seconds < 10){
				secondText = "0" + seconds.ToString();
			}else{
				secondText = seconds.ToString();
			}
			counter.text = minuteText + ":" + secondText;
		}
		timeLeft -= Time.deltaTime;
		if(timeLeft <= 0){
			finished = true;
			counter.text = "";
		}
	}
	void Update () {
		if(!isPaused && !startup){
			ShowTimer();	
			if(NextBeat()){
				currentBeat ++;
				if(currentBeat > 4){
					currentBeat = 1;
				}
				flashController.StartFlash(currentBeat);
				if(currentBeat == 2){
					staff.GetComponent<StaffScript>().ShowNote(nextNote.position, nextNote.sharp, nextNote.flat, nextNote.clef);
					StartCoroutine(noteController.Fade(noteMaterial, clefMaterial, noteDelay, nextNote.clef != lastNote.clef, colourController.getItem()));
				}else if(currentBeat == 1){
					lastNote = nextNote;
					nextNote = NextNote();
					if(!finished) StartCoroutine(noteController.Fade(noteMaterial, clefMaterial, noteDelay, nextNote.clef != lastNote.clef, colourController.getBG()));
				}
				if(currentBeat == 1 && finished){
					counter.text = "Finished";
					counter.color = colourController.getItem();
					isPaused = true;
				}
			}
		}
	}
	
	public void ToMenu(){
		
		isPaused = true;
		StartCoroutine(colourController.SceneChange("Menu"));
	}

	private bool NextBeat(){
		if(Time.time >= nextNoteTime){
			nextNoteTime = nextNoteTime + noteDelay;
			return true;
		}
		return false;
	}

	private Tools.Note NextNote(){
		int nextNoteNumber;
		int difficulty;
		nextNoteNumber = Random.Range(globalData.bottomNote, globalData.topNote + 1);
		difficulty = Random.Range(0, globalData.noteDifficulty + 1);
		return noteController.GetNextNote(nextNoteNumber, difficulty);
	}

} 
