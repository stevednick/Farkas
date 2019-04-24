using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour{

	public int bottomNote;
	public int topNote;
	public int bPM;
	public int duration;
	public bool showTimer;
	public bool soundOn;
	public int currentColourScheme;
	public int noteDifficulty;
	public int clef1;
	public int clef2;
	public int extraLedgerLines;

	public void Awake () {  
		clef1 = PlayerPrefs.GetInt("clef1"); 
		clef2 = PlayerPrefs.GetInt("clef2");
		currentColourScheme = PlayerPrefs.GetInt("colourScheme");
		bottomNote = PlayerPrefs.GetInt("bottom");
		topNote = PlayerPrefs.GetInt("top");
		bPM = PlayerPrefs.GetInt("bPM");
		duration = PlayerPrefs.GetInt("duration");
		showTimer = PlayerPrefs.GetInt("showTimer") == 1;
		soundOn = PlayerPrefs.GetInt("soundOn") == 1;
		noteDifficulty = PlayerPrefs.GetInt("noteDifficulty");
		extraLedgerLines = PlayerPrefs.GetInt("extraLedgerLines");
	}
	
	
	private void OnDestroy() {
		PlayerPrefs.SetInt("bottom", (int) bottomNote);
		PlayerPrefs.SetInt("top", (int) topNote);
		PlayerPrefs.SetInt("bPM", (int) bPM);
		PlayerPrefs.SetInt("duration", (int) duration);
		PlayerPrefs.SetInt("showTimer", showTimer ? 1 : 0);
		PlayerPrefs.SetInt("soundOn", soundOn ? 1 : 0);
		PlayerPrefs.SetInt("colourScheme", currentColourScheme);
		PlayerPrefs.SetInt("noteDifficulty", noteDifficulty);
		PlayerPrefs.SetInt("clef1", clef1);
		PlayerPrefs.SetInt("clef2", clef2);
		PlayerPrefs.SetInt("extraLedgerLines", extraLedgerLines);
	}
}
