using UnityEngine;

public class NoteScript : MovingObject { // Tidy this up when you're more awake. This is too confusing for the train journey! 

	[SerializeField]
	private GameObject notePrefab;
	[SerializeField]
	private GameObject linePrefab;
	private int position;
	public override void Start () {

		base.Start();
		notePrefab.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 1);
		}

	public void NoteStartup(int pos, string accidental){
		PositionNote(pos);
		SortLedgerLines(pos);
		notePrefab.transform.Find("Sharp").gameObject.SetActive(accidental == "sharp");
		notePrefab.transform.Find("Flat").gameObject.SetActive(accidental == "flat");
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
}
