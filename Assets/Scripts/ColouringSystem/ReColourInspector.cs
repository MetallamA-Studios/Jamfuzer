using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(ReColourRoomScript))]
public class ReColourInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ReColourRoomScript myScript = (ReColourRoomScript)target;

        if (GUILayout.Button("Re Colour"))
        {
            myScript.ReColour();
        }
    }
}
