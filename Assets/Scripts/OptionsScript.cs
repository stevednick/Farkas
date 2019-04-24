using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour {

	private ColourController colourController;
	private GlobalData globalData;
	[SerializeField]
	private Text countdownButtonText;
	[SerializeField]
	private Text difficultyButtonText;
	[SerializeField]
	private Text ledgerLinesButtonText;
	[SerializeField]
	private Text upperClefText;
	[SerializeField]
	private Text lowerClefText;
	[SerializeField]
	private float fadeDuration; 
	
	void Start ()
    {
        globalData = GetComponent<GlobalData>();
        colourController = GetComponent<ColourController>();
        colourController.SortColours();
		FixText();
        StartCoroutine(colourController.SceneChange(""));
        
    }

    private void FixText()
    {
        countdownButtonText.text = globalData.showTimer ? "Countdown On" : "Countdown Off";
        difficultyButtonText.text = displayNoteDifficulty(globalData.noteDifficulty);
        ledgerLinesButtonText.text = "Extra Ledger Lines: " + Tools.ledgerLinesText[globalData.extraLedgerLines];
        upperClefText.text = "Upper Clef: " + Tools.clefNames[globalData.clef1];
        lowerClefText.text = "Lower Clef: " + Tools.clefNames[globalData.clef2];
    }


	public void BackButtonPressed(){
		StartCoroutine(colourController.SceneChange("Menu"));
	}
	public void CountdownButtonPressed(){
		globalData.showTimer = !globalData.showTimer;
		countdownButtonText.text = globalData.showTimer ? "Countdown On" : "Countdown Off";
	}
	public void colourButtonPressed(){
		StartCoroutine(colourController.ChangeColourScheme(fadeDuration));
	}
	public void noteDifficultyButtonPressed(){
		globalData.noteDifficulty = globalData.noteDifficulty >= Tools.difficulties - 1 ? 0 : globalData.noteDifficulty + 1; //counts from one to display more easily.
		difficultyButtonText.text = displayNoteDifficulty(globalData.noteDifficulty);
		Debug.Log(globalData.noteDifficulty);
	}

	private string displayNoteDifficulty(int dif){
		if(dif == 0) return "Accidentals: (L1) C#, Eb, F#, Ab, Bb";
		if(dif == 1) return "Accidentals: (L2) Db, D#, Gb, G#, A#";
		if(dif == 2) return "Accidentals: (L3) Fb, E#, Cb, B#";
		return "Something has gone wrong!";
	}
	public void ledgerLinesButtonPressed(){
		globalData.extraLedgerLines = globalData.extraLedgerLines >= Tools.ledgerLinesText.Length - 1 ? 0 : globalData.extraLedgerLines + 1;
		ledgerLinesButtonText.text = "Extra Ledger Lines: " + Tools.ledgerLinesText[globalData.extraLedgerLines];
	}
	public void UpperClefButtonPressed(){
		globalData.clef2 = Tools.numberOfClefs;
		globalData.clef1 = globalData.clef1 >= Tools.numberOfClefs - 1 ? 0 : globalData.clef1 + 1;
		upperClefText.text = "Upper Clef: " + Tools.clefNames[globalData.clef1];
		lowerClefText.text = "Lower Clef: " + Tools.clefNames[globalData.clef2];
	}
	public void LowerClefButtonPressed(){
		globalData.clef2 += 1;
		if(globalData.clef2 > Tools.numberOfClefs) globalData.clef2 = 0;
		while(globalData.clef2 <= globalData.clef1){
			globalData.clef2 += 1;
		}
		
		lowerClefText.text = "Lower Clef: " + Tools.clefNames[globalData.clef2];
	}
}
