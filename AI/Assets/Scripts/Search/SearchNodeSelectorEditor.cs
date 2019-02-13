using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SearchNodeSelector))]
public class SearchNodeSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SearchNodeSelector selector = (SearchNodeSelector)target;
        if (GUILayout.Button("Execute"))
        {
            selector.Execute();
        }
        if (GUILayout.Button("Reset All"))
        {
            selector.ResetSourceDestination();
            selector.ResetNodes();
        }
        if (GUILayout.Button("Reset Path"))
        {
            selector.ResetNodes();
        }
        if (GUILayout.Button("Random Source"))
        {
            selector.RandomSource();
        }
        if (GUILayout.Button("Random Destination"))
        {
            selector.RandomDestination();
        }
    }
}
