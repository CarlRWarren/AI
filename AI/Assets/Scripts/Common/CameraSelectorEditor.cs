using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraSelector))]
public class CameraSelectorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		CameraSelector selector = (CameraSelector)target;
		if (GUILayout.Button("Next"))
		{
			selector.Next();
		}
	}
}
