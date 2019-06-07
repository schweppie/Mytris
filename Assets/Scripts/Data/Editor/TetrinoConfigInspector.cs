using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CustomEditor(typeof(TetrinoConfig))]
    public class TetrinoConfigInspector : Editor
    {
        TetrinoConfig tetrinoConfig;

        private const int CELL_SIZE = 10;

        private int patternDimensions;

        public void OnEnable()
        {
            tetrinoConfig = target as TetrinoConfig;
            patternDimensions = (int)Mathf.Sqrt(tetrinoConfig.Pattern.Length);
        }

        public override void OnInspectorGUI()
        {
            int xOffset = 16;
            int yOffset = 80;
            Rect toggleRect = new Rect(0,0,CELL_SIZE,CELL_SIZE);

            int i = 0;
            for(int y=0; y < patternDimensions; y++)
            {
                for(int x=0; x < patternDimensions; x++)
                {
                    toggleRect.x = x * CELL_SIZE + xOffset; toggleRect.y = y* CELL_SIZE + yOffset;
                    tetrinoConfig.Pattern[i] = EditorGUI.Toggle(toggleRect, tetrinoConfig.Pattern[i]);
                    i++;
                }
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("VisualizerPrefab"));
        }
    }
}
