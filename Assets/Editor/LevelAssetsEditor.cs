using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Level))][CanEditMultipleObjects]
public class LevelAssetsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Level level = (Level)target;

        if(GUILayout.Button("Clear Player Data"))
        {
            level.ClearLevel();
        }

        GUILayout.Space(5);

        if(GUILayout.Button("Reset Level Info"))
        {
            level.ResetLevel();
        }
    }
}
