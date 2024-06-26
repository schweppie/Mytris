﻿using UnityEditor;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CustomEditor(typeof(TetrinoConfig))]
    public class TetrinoConfigInspector : Editor
    {
        private TetrinoConfig tetrinoConfig;

        public void OnEnable()
        {
            tetrinoConfig = (TetrinoConfig)target;
        }

        public override void OnInspectorGUI()
        {
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BlockConfig"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TetrinoVisualizer"));

            tetrinoConfig.Color = EditorGUILayout.ColorField(tetrinoConfig.Color);

            EditorUtility.SetDirty(this);
            EditorUtility.SetDirty(tetrinoConfig);

            GUILayout.BeginHorizontal();

            if(GUILayout.Button("Add"))
                tetrinoConfig.AddPattern();

            if(GUILayout.Button("Remove"))
                tetrinoConfig.RemovePattern(tetrinoConfig.Patterns.Count-1);

            GUILayout.EndHorizontal();

            for(int i=0; i< tetrinoConfig.Patterns.Count; i++)
            {
                DrawPattern(i);
            }
        }

        private void DrawPattern(int i)
        {
            TetrinoPattern pattern = tetrinoConfig.Patterns[i];

            GUILayout.Label(" Pattern " + i );

            pattern.ForceInitialize(tetrinoConfig.PatternWidth, tetrinoConfig.PatternHeight);

            for(int y=tetrinoConfig.PatternHeight-1; y >=0 ; y--)
            {
                GUILayout.BeginHorizontal();
                for(int x=0; x< tetrinoConfig.PatternWidth; x++)
                {
                    pattern.SetValue(x,y, GUILayout.Toggle(pattern.GetValue(x,y), ""));
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}
