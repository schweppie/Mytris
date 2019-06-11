using UnityEditor;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CustomEditor(typeof(TetrinoConfig))]
    public class TetrinoConfigInspector : Editor
    {
        private TetrinoConfig tetrinoConfig;
        private const int CELL_SIZE = 10;
        private const int PATTERN_MARGIN = 50;

        private float yDrawOffset;

        private int width;
        private int height;

        public void OnEnable()
        {
            tetrinoConfig = target as TetrinoConfig;
            
            width = tetrinoConfig.PatternWidth;
            height = tetrinoConfig.PatternHeight;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("BlockConfig"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TetrinoVisualizer"));


            height = Mathf.Max(1,EditorGUILayout.IntField("Height", height));
            width = Mathf.Max(1,EditorGUILayout.IntField("Width", width));
            
            if(GUILayout.Button("Initialize"))
            {
                if(EditorUtility.DisplayDialog("Warning", "Reinitialize pattern? Current data will be lost.", "Ok", "Cancel"))
                {
                    tetrinoConfig.PatternWidth = width;
                    tetrinoConfig.PatternHeight = height;
                    tetrinoConfig.InitializePatterns();
                }
            }                
            
            yDrawOffset = 100;

            for(int i=0; i< tetrinoConfig.Patterns.Count; i++)
            {
                yDrawOffset += tetrinoConfig.PatternHeight * CELL_SIZE + PATTERN_MARGIN;
                DrawPattern(i);
            }

            if(GUILayout.Button("Add"))
                tetrinoConfig.AddPattern();
        }

        private void DrawPattern(int index)
        {
            Rect toggleRect = new Rect(0,0,CELL_SIZE,CELL_SIZE);

            int i = 0;
            for(int y=0; y < tetrinoConfig.PatternHeight; y++)
            {
                for(int x=0; x < tetrinoConfig.PatternWidth; x++)
                {
                    toggleRect.x = x * CELL_SIZE + 16; toggleRect.y = y* CELL_SIZE + yDrawOffset;
                    tetrinoConfig.Patterns[index][x,y] = EditorGUI.Toggle(toggleRect, tetrinoConfig.Patterns[index][x,y]);
                    i++;
                }
            }

            if(GUI.Button(new Rect((CELL_SIZE + 16) * tetrinoConfig.PatternWidth  + 50, yDrawOffset, 50, 16), "X"))
                tetrinoConfig.RemovePattern(index);
        }
    }
}
