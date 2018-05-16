using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PrimitiveBarrier))]
public class PrimitiveBarrierEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("Here we can write tips for using this script in the editor mode! Very useful. To modify this, go to the Editor folder, PrimitiveBarrierEditor script.", MessageType.Info);
    }
}
