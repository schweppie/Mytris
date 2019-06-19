using System;
using System.Collections;
using System.Collections.Generic;
using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CreateAssetMenu(menuName = "Data/TetrinoConfig", fileName = "TetrinoConfig")]
    [Serializable]
    public class TetrinoConfig : ScriptableObject
    {
        public BlockConfig BlockConfig;

        public TetrinoVisualizer TetrinoVisualizer;

        public Color Color;

        public int PatternWidth = 5;
        public int PatternHeight = 5;


        [SerializeField]
        private List<TetrinoPattern> patterns = new List<TetrinoPattern>();

        public List<TetrinoPattern> Patterns
        {
            get{ return patterns;}
        }

        public void AddPattern()
        {
            patterns.Add(new TetrinoPattern(5,5));
        }

        public void RemovePattern(int index)
        {
            patterns.RemoveAt(index);
        }
    }
}
