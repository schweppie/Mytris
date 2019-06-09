using UnityEditor;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CustomEditor(typeof(TetrinoConfig))]
    public class TetrinoConfigInspector : Editor
    {
        private TetrinoConfig tetrinoConfig;
        private const int CELL_SIZE = 10;

        public void OnEnable()
        {
            tetrinoConfig = target as TetrinoConfig;
        }

        public override void OnInspectorGUI()
        {
            int xOffset = 16;
            int yOffset = 100;
            Rect toggleRect = new Rect(0,0,CELL_SIZE,CELL_SIZE);

            int i = 0;
            for(int y=0; y < DataHelper.TETRINO_DIMENSION; y++)
            {
                for(int x=0; x < DataHelper.TETRINO_DIMENSION; x++)
                {
                    toggleRect.x = x * CELL_SIZE + xOffset; toggleRect.y = y* CELL_SIZE + yOffset;
                    tetrinoConfig.Pattern[i] = EditorGUI.Toggle(toggleRect, tetrinoConfig.Pattern[i]);
                    i++;
                }
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("BlockConfig"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TetrinoVisualizer"));
            
        }
    }
}
