using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemitoneStore: MonoBehaviour{

	public int[,] positions = new int[12,3]{
		{0, 0, -1}, // c/b#
		{0, 1, 0}, 	// c#/db
		{1, 0, 0},  // d
		{2, 1, 0},	// eb/d#
		{2, 0, 3},	// e/fb
		{3, 0, 0},	//f
		{3, 4, 0},	//f#/gb
		{4, 0, 0},	//g
		{5, 4, 0},	//ab/g#
		{5, 0, 0},	//a
		{6, 5, 0},	//bb/a#
		{6, 0, 7}	//b/cb
	};

	string[,] accidentals = new string[12,3]{
		{"natural", "null", "sharp"}, // c/b#
		{"sharp", "flat", "null"}, 	// c#/db
		{"natural", "null", "null"},  // d
		{"flat", "sharp", "null"},	// eb/d#
		{"natural", "null", "flat"},	// e/fb
		{"natural", "null", "null"},	//f
		{"sharp", "flat", "null"},	//f#/gb
		{"natural", "null", "null"},	//g
		{"flat", "sharp", "null"},	//ab/g#
		{"natural", "null", "null"},	//a
		{"flat", "sharp", "null"},	//bb/a#
		{"natural", "null", "flat"}	//b/cb
	};

	public string[] names = new string[12]
		{"C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B"};

	public string[] octaveNames = new string[7]
		{"Super Bottom", "Bottom", "Low", "Middle", "High", "Top", "Super"};

	public Tools.SemitoneInfo getSemitone(int number, int desiredDifficulty){
		int p;
		string a;
		if(accidentals[number, desiredDifficulty] != "null"){
			p = positions[number, desiredDifficulty];
			a = accidentals[number, desiredDifficulty];
		}else{
			p = positions[number, 0];
			a = accidentals[number, 0];
		}
		return new Tools.SemitoneInfo{position = p, accidental = a};
	}
	
}
