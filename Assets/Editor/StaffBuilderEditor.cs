using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaffScript))]
public class StaffBuilderEditor : Editor {

	#if UNITY_EDITOR
	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        StaffScript myScript = (StaffScript)target;
        if(GUILayout.Button("Build Staff"))
        {
            myScript.GenerateStaff();
        }
    }
    #endif
}

