using UnityEngine;

public class NoteScript : MovingObject {

	[SerializeField]
	private GameObject notePrefab;
	[SerializeField]
	private GameObject linePrefab;
	private int position;
	Vector3 topPoint;
	public override void Start () {

		base.Start();
		notePrefab.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 1);
		}

	public void NoteStartup(int pos, string accidental){
		PositionNote(pos);
		SortLedgerLines(pos);
		notePrefab.transform.Find("Sharp").gameObject.SetActive(accidental == "sharp");
		notePrefab.transform.Find("Flat").gameObject.SetActive(accidental == "flat");
		Transform top = null;
		if(pos > 0){
			top = notePrefab.transform.Find("ICTop").transform;
		}else{
			top = notePrefab.transform.Find("CrotchetTop").transform;
		}
		topPoint = top.position;
		Debug.Log(topPoint);
		Debug.Log(top.localPosition);
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
        ledger.transform.localScale = new Vector3(Tools.ledgerLength * Tools.lineGap, Tools.lineWidth, 1);
        ledger.transform.gameObject.SetActive(true);
        ledger.transform.parent = transform;
    }
	public Vector3 getHighestPoint(){

		return topPoint;
	}
}
