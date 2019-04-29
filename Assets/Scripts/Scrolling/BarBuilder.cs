using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarBuilder : MonoBehaviour {

	public GameObject spherePrefab;
	public void BuildBar(){
		Instantiate(spherePrefab, new Vector3(6.85f, 0, 0), Quaternion.identity);
	}
}
