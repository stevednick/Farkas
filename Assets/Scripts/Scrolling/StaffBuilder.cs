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
	public GameObject arrowPrefab;
	public float arrowX;
	public GameObject SpherePrefab;


	void DrawLines()
    {
        float width = GetScreenWidth();
		for(int i=0; i<5; i++){
			DrawLine(i);
		}

		barLine = Instantiate(linePrefab, transform.position + new Vector3(- width/2f + Tools.lineWidth, 0, 0), transform.rotation);
		barLine.transform.localScale = new Vector3(Tools.lineWidth * 2, Tools.lineGap * 4, 1);
		barLine.transform.parent = transform;
    }

	void DrawLine(int lineNumber){
		 GameObject line = Instantiate(linePrefab, transform.position + new Vector3(0, Tools.lineGap * (lineNumber - 2), 0), transform.rotation);
		 line.transform.localScale = new Vector3(GetScreenWidth(), Tools.lineWidth, 1);
		 line.transform.parent = transform;

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
		PlaceSphere();
		//PlaceArrow();
	}
	public void PlaceArrow(){
		GameObject arrow = Instantiate(arrowPrefab, transform.position + new Vector3(arrowX, 1, 0), transform.rotation);
		arrow.transform.localScale = new Vector3(Tools.lineGap, Tools.lineGap, 0.2f);
		arrow.transform.parent = transform;
	}
	void PlaceSphere(){
		GameObject bounce = Instantiate(SpherePrefab, transform.position + new Vector3(-1f, 1.5f, 0), transform.rotation);
		bounce.transform.parent = transform;
	}

}
