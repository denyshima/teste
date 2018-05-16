using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Attribute that enables custom editor features
[CustomEditor(typeof(PrimitiveEffect))]
public class PrimitiveEffectsEditor : Editor {

    // Note that this is not a MonoBehaviour, but an Editor child
    // Bellow we override the OnInspectorGUI that unity uses as default for this script only
    public override void OnInspectorGUI()
    {
        // We choose to draw the default inspector anyway, since we just want to add things
        DrawDefaultInspector();
        // Now we add a helpbox in the inspector
        EditorGUILayout.HelpBox("Look for the Editor folder, PrimitiveEffectsEditor script, to understand how it works! We can use it for more things, like adding a custom field that is not a PUBLIC variable!", MessageType.Info);
    }
}
