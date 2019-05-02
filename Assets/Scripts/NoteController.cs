using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour {
	[SerializeField]
	private GlobalData globalData;
	[SerializeField]
	private SemitoneStore semitoneStore;

	public IEnumerator Fade(Material note, Material clef, float duration, bool staffInculded, Color target){
		float start = Time.time;
		Color startColour = note.color;
		while(Time.time <= start + duration){
			
			Color colour = Color.Lerp(startColour, target, (Time.time-start)/duration);
			note.color = colour;
			if(staffInculded) clef.color = colour;
			yield return 0;
		}
	}
	public Tools.Note GetNextNote(int num, int dif){
		Tools.Note n = new Tools.Note();
		int noteInOctave = GetNoteInOctave(num);
		int octave = GetOctave(num);
		Tools.SemitoneInfo semiInfo = semitoneStore.getSemitone(noteInOctave, dif);
		int posToMidC = semiInfo.position + (octave * 7);
		string clef = GetClef(posToMidC);
		int positionOnStave = Tools.clefMidCPos[clef] + posToMidC;
		n.clef = clef;
		n.flat = (semiInfo.accidental == "flat");
		n.sharp = (semiInfo.accidental == "sharp");
		n.position = positionOnStave;
		return n;
	}

	public int GetNoteInOctave(int num){
		int n = num % 12;
		n = n < 0 ? n + 12 : n;
		return n;
	}

	public int GetOctave(int num){
		return Mathf.FloorToInt(((float)num/12f));
	}

	public string GetClef(int posC){ // adjust for more clefs
		string c1 = Tools.clefNames[globalData.clef1];
		string c2 = Tools.clefNames[globalData.clef2];

		if(c2 == "Off"){
			return c1;
		}else if(posC + Tools.clefMidCPos[c1] < - (6 + globalData.extraLedgerLines)){ 
			return c2;
		}else if(posC + Tools.clefMidCPos[c2] > 6 + globalData.extraLedgerLines){
			return c1;
		}else {
			return (Random.value > 0.5f ? c1 : c2);
		}	
	}

	public string GetNoteName(int num){
		string name = semitoneStore.names[GetNoteInOctave(num)];
		string octave = semitoneStore.octaveNames[GetOctave(num) + 3];
		return octave + " " + name;
	}

	public int getHighestAllowedNote(){
		int linesRelativeToMidCLoc = Tools.maxLinesFromMiddle - Tools.clefMidCPos[Tools.clefNames[globalData.clef1]];
		int octave = Mathf.FloorToInt((float)linesRelativeToMidCLoc / 7f);
		int lineInOctave = linesRelativeToMidCLoc - (octave * 7);
		int posInOctave = 0;
		for(int i = 0; i<12; i++){
			if(semitoneStore.positions[i,0] == lineInOctave){
				posInOctave = i;
				break;
			}
		}
		return posInOctave + (octave * 12);
	}

		public int getLowestAllowedNote(){
		int clefToCheck = Tools.clefNames[globalData.clef2] == "Off" ? globalData.clef1 : globalData.clef2;
		int linesRelativeToMidCLoc = - Tools.maxLinesFromMiddle - Tools.clefMidCPos[Tools.clefNames[clefToCheck]];
		int octave = Mathf.FloorToInt((float)linesRelativeToMidCLoc / 7f);
		int lineInOctave = linesRelativeToMidCLoc - (octave * 7);
		int posInOctave = 0;
		for(int i = 11; i >= 0; i--){
			if(semitoneStore.positions[i,0] == lineInOctave){
				posInOctave = i;
				break;
			}
		}
		return posInOctave + (octave * 12);
	}


}
