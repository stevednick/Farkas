using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour {

    public float bottomNote {get;set;}
	public float topNote {get;set;}
	public float bPM {get; set;}
	[SerializeField]
	private Text topSliderText;
	[SerializeField]
	private Text bottomSliderText;
	[SerializeField]
	private Slider topSlider;
	[SerializeField]
	private Slider bottomSlider;
	[SerializeField]
	private Text bPMText;
	[SerializeField]
	private Slider bPMSlider;
	[SerializeField]
	private Slider durationSlider;
	[SerializeField]
	private Text durationText;
	[SerializeField]
	private Text soundText;
	[SerializeField]
	public float duration {get; set;}
	[SerializeField]
	private ColourController colourController;
	[SerializeField]
	private GlobalData globalData;
	private bool sliderBugFix = true;
	[SerializeField]
	private NoteController noteController;

	void Awake () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//timerButtonText.text = globalData.showTimer ? "Countdown: On": "Countdown: Off";
		soundText.text = globalData.soundOn ? "Sound: On": "Sound: Off";
		bottomNote = globalData.bottomNote;
		topNote = globalData.topNote;
		duration = globalData.duration;
		bPM = globalData.bPM;
		topSlider.value = topNote;
		bottomSlider.value = bottomNote;
		bPMSlider.value = bPM;
		durationSlider.value = duration;
		colourController.SortColours();
		StartCoroutine(colourController.SceneChange(""));
		sliderBugFix = false;
		SliderUpdate();
		
	}

	public void soundButtonPressed(){
		globalData.soundOn = !globalData.soundOn;
		soundText.text = globalData.soundOn ? "Sound: On": "Sound: Off";
	}

	public void OptionsButtonPressed(){
		StartCoroutine(colourController.SceneChange("Options"));
	}

	public void SliderUpdate(){ 

		if(!sliderBugFix){
			topSlider.maxValue = noteController.getHighestAllowedNote();
			topSlider.minValue = bottomSlider.value > noteController.getHighestAllowedNote() ? noteController.getHighestAllowedNote() : bottomSlider.value;
			bottomSlider.maxValue = topSlider.value < noteController.getLowestAllowedNote() ? noteController.getLowestAllowedNote() : topSlider.value;
			bottomSlider.minValue = noteController.getLowestAllowedNote();
			topSliderText.text = "Upper Limit: " + GetNoteName((int)topSlider.value); //	noteNames[(int)topSlider.value + 24];
			bottomSliderText.text = "Lower Limit: " + GetNoteName((int)bottomSlider.value); //	noteNames[(int)bottomSlider.value + 24];
			bPMText.text = "BPM: " + bPM.ToString();
			int d = (int) duration;
			if(d <= 60){
				durationText.text = "Duration: " + ((d - (d % 6))/6).ToString() + ":" + (d % 6).ToString() + "0";
			}else if (d == 61){
				durationText.text = "Keep Going";
			}
		}	

	}

	private string GetNoteName(int num){
		string noteName = noteController.GetNoteName(num);
		return noteName;
		
	}
	public void ToMainScene()
    {
        SaveSliderDetails();
        StartCoroutine(colourController.SceneChange("Main"));
    }

    private void SaveSliderDetails()
    {
        globalData.bottomNote = (int)bottomNote;
        globalData.topNote = (int)topNote;
        globalData.duration = (int)duration;
        globalData.bPM = (int)bPM;
    }

    void OnDestroy()
	{
		SaveSliderDetails();
	}
}
