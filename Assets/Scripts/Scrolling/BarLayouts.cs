using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarLayouts{

	public static float beatSpacing = 4f * Tools.lineGap;
	public static int beatsPerBar = 4;
	public static Dictionary<string, float> crotchetBar = new Dictionary<string, float>(){{"Clef", 0.1f}, {"Note", 0.25f}, {"CrotchetRest", 0.5f}, {"MinimRest",0.75f}};
	public static Dictionary<string, float> testBar = new Dictionary<string, float>(){{"Dot0", 0}, {"Dot1", 0.25f}, {"Dot2", 0.5f}, {"Dot3", 0.75f}};
	public static Dictionary<string, float> buildingBar = new Dictionary<string, float>(){{"BarLine", 0}, {"Clef", 0.1f}, {"Note", 0.32f}, {"CRest", 0.5f}, {"MRest", 0.75f}};
	public static Dictionary<string, float> clefBeforeStaff = new Dictionary<string, float>(){{"BarLine", 0}, {"Clef", -0.12f}, {"Note", 0.2f}, {"CRest", 0.42f}, {"MRest", 0.68f}};

	// What about having a dictionary of gameobjects and values? Probably won't work with a class...

}
