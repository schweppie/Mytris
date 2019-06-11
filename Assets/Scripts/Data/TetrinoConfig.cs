using System.Collections;
using System.Collections.Generic;
using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CreateAssetMenu(menuName = "Data/TetrinoConfig", fileName = "TetrinoConfig")]
    public class TetrinoConfig : ScriptableObject
    {
        public BlockConfig BlockConfig;

        public TetrinoVisualizer TetrinoVisualizer;

        public int PatternWidth = 5;
        public int PatternHeight = 5;

        public List<bool[,]> Patterns = new List<bool[,]>();

        public void InitializePatterns()
        {
            Patterns = new List<bool[,]>();

            for(int i=0; i < 1; i++)
                Patterns.Add(new bool[PatternWidth, PatternHeight]);
        }

        public void AddPattern()
        {
            Patterns.Add(new bool[PatternWidth, PatternHeight]);
        }

        public void RemovePattern(int index)
        {
            Patterns.RemoveAt(index);
        }
    }
}
