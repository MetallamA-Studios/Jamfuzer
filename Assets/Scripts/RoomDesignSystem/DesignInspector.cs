using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[CustomEditor(typeof(DesignRoomScript))]
public class DesignInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DesignRoomScript myScript = (DesignRoomScript)target;

        if (GUILayout.Button("Re Colour"))
        {
            myScript.ReColour();
        }

        if (GUILayout.Button("Re Decorate"))
        {
            myScript.ReDecor();
        }
    }
}
