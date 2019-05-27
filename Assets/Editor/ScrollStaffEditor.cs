using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StaffBuilder))]
public class ScrollStaffEditor : Editor {

	#if UNITY_EDITOR
	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        StaffBuilder myScript = (StaffBuilder)target;
        if(GUILayout.Button("Build Staff"))
        {
            myScript.GenerateStaff();
        }
    }
    #endif
}
