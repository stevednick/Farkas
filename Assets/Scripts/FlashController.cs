using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour {
	[SerializeField]
	private GameObject flash;
	[SerializeField]
	private Material flashMaterial;
	[SerializeField]
	private float[] flashScale = {0, 2, 4}; //sizes of flash cylinder, flashScale [1] for beats 234, [2] for beat 1 (needs tidying)
	[SerializeField]
	private float flashDuration;

	[SerializeField]
	private float fadeDuration;
	[SerializeField]
	private AudioClip highTick;
	[SerializeField]
	private AudioClip lowTick;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
		source.volume = PlayerPrefs.GetInt("soundOn");
	}

	public void StartFlash(int beat){
		if(beat == 1){
			flash.GetComponent<Renderer>().material.color = Color.green;
			source.PlayOneShot(highTick);
			StartCoroutine(Flash(flash, flashScale[0], flashScale[2], flashDuration, true));
		}else{
			flash.GetComponent<Renderer>().material.color = Color.red;
			source.PlayOneShot(lowTick);
			StartCoroutine(Flash(flash, flashScale[0], flashScale[1], flashDuration, false));
		}
	}
	private static IEnumerator Flash(GameObject f, float startScale, float targetScale, float duration, bool shrink){
		f.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
		yield return new WaitForSeconds(duration);
		if(shrink){
			float start = Time.time;
			while (Time.time <= start + duration){
				float s = Mathf.Lerp(targetScale, startScale, (Time.time - start)/duration);
				f.transform.localScale = new Vector3(s, s, s);
				yield return null;
			}
		}

		f.transform.localScale = new Vector3(startScale, startScale, startScale);
	}

}
