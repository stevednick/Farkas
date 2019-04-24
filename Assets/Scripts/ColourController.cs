using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColourController : MonoBehaviour {	
	
	public static int numberOfColourSchemes = 5; //remember to change colours[] below
	
	[SerializeField]
	private Camera mainCamera;
	[SerializeField]
	private GameObject[] sliderBits;
	[SerializeField]
	private Text[] allText;
	private ColourScheme whiteOnBlack = new ColourScheme{bGColour = Color.black, itemColour = Color.white};
	private ColourScheme blackOnWhite = new ColourScheme{bGColour = Color.white, itemColour = Color.black};
	private ColourScheme blackOnGreen = new ColourScheme{bGColour = new Color(0.75f, 1f, 0.75f, 1f) , itemColour = Color.black};
	private ColourScheme blackOnLightGreen = new ColourScheme{bGColour = new Color(0.85f, 1f, 0.85f, 1f) , itemColour = Color.black};
	private ColourScheme blackOnBlue = new ColourScheme{bGColour = new Color(0.7f, 0.8f, 1f, 1f), itemColour = Color.black};
	private ColourScheme[] colours = new ColourScheme[5];
	[SerializeField]
	private GlobalData globalData;
	[SerializeField]
	private RawImage cover;

	private void Awake() {
		colours[0] = whiteOnBlack;
		colours[1] = blackOnWhite;
		colours[2] = blackOnGreen;
		colours[3] = blackOnLightGreen;
		colours[4] = blackOnBlue;
	}

	public IEnumerator ChangeColourScheme(float duration){
		Color bGStart = colours[globalData.currentColourScheme].bGColour;
		Color itemStart = colours[globalData.currentColourScheme].itemColour;
		globalData.currentColourScheme ++;
		if (globalData.currentColourScheme >= numberOfColourSchemes){
			globalData.currentColourScheme = 0;
		}
		Color bGTarget = colours[globalData.currentColourScheme].bGColour;
		Color itemTarget = colours[globalData.currentColourScheme].itemColour;
		float startTime = Time.time;
		while (Time.time <= startTime + duration){
			mainCamera.backgroundColor = Color.Lerp(bGStart, bGTarget, (Time.time - startTime)/duration);
			foreach(GameObject bit in sliderBits){
				bit.GetComponent<Image>().color = Color.Lerp(itemStart, itemTarget, (Time.time - startTime)/duration);
			}
			foreach(Text t in allText){
				t.color = Color.Lerp(itemStart, itemTarget, (Time.time - startTime)/duration);
			}
			yield return null;
			
		}
		mainCamera.backgroundColor = bGTarget;
	}

	public IEnumerator SceneChange(string targetScene){  //  SceneChange class! 
		Color target = getBG(); //target is bg colour if leaving scene;
		Color start = new Color(target.r, target.g, target.b, 0);
		float startTime = Time.time;
		while (Time.time <= startTime + Tools.sceneFadeDuration){
			if(targetScene == ""){
				cover.color = Color.Lerp(target, start, (Time.time - startTime)/Tools.sceneFadeDuration);
			}else{
				cover.color = Color.Lerp(start, target, (Time.time - startTime)/Tools.sceneFadeDuration);
			}
			yield return null;
		}
		if(targetScene != ""){
			SceneManager.LoadScene(targetScene);
		}else{
			cover.color = Color.clear;
		}
	}

	public Color getBG(){
		return colours[globalData.currentColourScheme].bGColour;
	}

	public Color getItem(){
		return colours[globalData.currentColourScheme].itemColour;
	}

	public void SortColours(){
		cover.color = Color.clear;
		mainCamera.backgroundColor = colours[globalData.currentColourScheme].bGColour;
		foreach(GameObject bit in sliderBits){
			bit.GetComponent<Image>().color = colours[globalData.currentColourScheme].itemColour;
		}
		foreach(Text t in allText){
			t.color = colours[globalData.currentColourScheme].itemColour;;
		}
		
	}

	[SerializeField]
	private struct ColourScheme{

		private Color _bGColour;
		private Color _itemColour;
		public Color bGColour{
			get{
				return _bGColour;
			}
			set{
				_bGColour = value;
			}	
		}
		public Color itemColour{
			get{
				return _itemColour;
			}
			set{
				_itemColour = value;
			}	
		}

		public void Instantiate(Color _bg, Color _item){
			bGColour = _bg;
			itemColour = _item;
		}

	}
}
