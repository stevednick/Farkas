using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffBuilder : MonoBehaviour {
	[SerializeField]
	private GameObject linePrefab;
	[SerializeField]
	private float lineLength; //yes
	private GameObject line0;
	private GameObject line1;
	private GameObject line2;
	private GameObject line3;
	private GameObject line4;
	private GameObject barLine;
	public Camera mainCamera;
	public Material staffMaterial;
	public GameObject clefColliderPrefab;
	public float clefPosition;
	public GameObject objectKillColliderPrefab;
	public float objectKillPosition;


	void DrawLines()
    { // Tidy this bugger up! 
        float width = GetScreenWidth();
        line0 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap * 2, 0), transform.rotation);
        line1 = Instantiate(linePrefab, transform.position + new Vector3(0, -Tools.lineGap, 0), transform.rotation);
        line2 = Instantiate(linePrefab, transform.position, transform.rotation);
        line3 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap, 0), transform.rotation);
        line4 = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap * 2, 0), transform.rotation);
        line0.transform.localScale = new Vector3(width, Tools.lineWidth, 1);
        line1.transform.localScale = new Vector3(width, Tools.lineWidth, 1);
        line2.transform.localScale = new Vector3(width, Tools.lineWidth, 1);
        line3.transform.localScale = new Vector3(width, Tools.lineWidth, 1);
        line4.transform.localScale = new Vector3(width, Tools.lineWidth, 1);
        line0.transform.parent = transform;
        line1.transform.parent = transform;
        line2.transform.parent = transform;
        line3.transform.parent = transform;
        line4.transform.parent = transform;
		barLine = Instantiate(linePrefab, transform.position + new Vector3(- width/2f + Tools.lineWidth, 0, 0), transform.rotation);
		barLine.transform.localScale = new Vector3(Tools.lineWidth * 2, Tools.lineGap * 4, 1);
		barLine.transform.parent = transform;
    }

	void SetUpColliders(){
		GameObject clefCollider = Instantiate(clefColliderPrefab, transform.position + new Vector3(-GetScreenWidth()/2f + clefPosition, 0, 0), transform.rotation);
		clefCollider.transform.parent = transform;
		GameObject objectKillCollider = Instantiate(objectKillColliderPrefab, transform.position + new Vector3(-GetScreenWidth()/2f + objectKillPosition, 0, 0), transform.rotation);
		objectKillCollider.transform.parent = transform;
	}

    private float GetScreenWidth()
    {
        float height = mainCamera.orthographicSize * 2;
        float width = height * mainCamera.scaledPixelWidth / mainCamera.scaledPixelHeight;
        return width;
    }

    public void GenerateStaff(){ 
		

		int childs = transform.childCount;
 		for (int i = childs - 1; i >= 0; i--)
 		{
     		GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
 		}		
		DrawLines();
		SetUpColliders();
	}

}
