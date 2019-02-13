using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SearchNodeCreator))]
public class SearchNodeGridCreatorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		SearchNodeCreator creator = (SearchNodeCreator)target;
		if (GUILayout.Button("Generate"))
		{
			creator.ClearNodes();
			creator.CreateNodes();
			creator.LinkNodes();
		}
	}
}
