using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools{

	public static float lineGap = .6f;
	public static float ledgerLength = 2.1f;
	public static float lineWidth = 0.12f;
	public static int maxLinesFromMiddle = 13;
	public static string[] ledgerLinesText = new string[6]{
		"Minimum", "+1", "+2", "+3", "+4", "+5"
	};
	public static int difficulties = 3; //number of levels of enharmonic notes available. 
	public static float sceneFadeDuration = 0.5f;
	
	public static string[] clefNames = new string[5]{ // capital letters to display... 
		"Treble", "Alto", "Tenor", "Bass", "Off"
	};
	public static int numberOfClefs = 4;
	public static Dictionary<string, int> clefMidCPos = new Dictionary<string, int>(){{"Treble",-6},{"Bass",6}, {"Alto", 0}, {"Tenor", 2}};
	public struct SemitoneInfo{
		private int _pos;
		private string _acc;
		public int position{
			get{
				return _pos;
			}
			set{
				_pos = value;
			}	
		}
		public string accidental{
			get{
				return _acc;
			}
			set{
				_acc = value;
			}
		}	
	}
	public struct Note{
		private int _pos;
		private bool _flat;
		private bool _sharp;
		private string _clef;
		public int position{
			get{
				return _pos;
			}
			set{
				_pos = value;
			}	
		}
		public bool sharp{
			get{
				return _sharp;
			}
			set{
				_sharp = value;
			}	
		}
		public bool flat{
			get{
				return _flat;
			}
			set{
				_flat = value;
			}	
		}
		public string clef{
			get{
				return _clef;
			}
			set{
				_clef = value;
			}	
		}
	}
}
