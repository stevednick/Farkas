using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour {

	[SerializeField]
	private GameObject notePrefab;
	[SerializeField]
	private GameObject linePrefab;
	private int position;
	private float speed;
	void Start () {
		notePrefab.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 1);
		}

	public void NoteStartup(int pos, string accidental, float s){
		PositionNote(pos);
		SortLedgerLines(pos);
		notePrefab.transform.Find("Sharp").gameObject.SetActive(accidental == "sharp");
		notePrefab.transform.Find("Flat").gameObject.SetActive(accidental == "flat");
		speed = s;
	}

	void PositionNote(int pos){
		notePrefab.transform.localPosition = new Vector3(0, Tools.lineGap / 2f * pos, 0);
		notePrefab.transform.Find("Crotchet").gameObject.SetActive(pos <= 0);
		notePrefab.transform.Find("InvertedCrotchet").gameObject.SetActive(pos > 0);
	}

	void SortLedgerLines(int pos){
		for(int i = 6; i <= pos; i += 2){
            DrawLedgerLine(Mathf.FloorToInt(i/2));
        }
		for(int i = -6; i >= pos; i -= 2){
			DrawLedgerLine(Mathf.FloorToInt(i/2));
		}
    }

    private void DrawLedgerLine(int multiplier)
    {
        GameObject ledger = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap * multiplier, 0), transform.rotation);
        ledger.transform.localScale = new Vector3(Tools.ledgerLength, Tools.lineWidth, 1);
        ledger.transform.gameObject.SetActive(true);
        ledger.transform.parent = transform;
    }

	void Move(){
		transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
	}

    void Update () {
		/*
		if(Input.GetKeyDown("down")){
			position --;
			NoteStartup(position, "sharp");
		}
		if(Input.GetKeyDown("up")){
			position ++;
			NoteStartup(position, "flat");
		}
		*/
		Move();
		if(transform.position.x < -15){
			Destroy(gameObject);
		}
	}
}
