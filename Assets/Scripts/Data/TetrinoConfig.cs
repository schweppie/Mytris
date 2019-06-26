using System;
using System.Collections;
using System.Collections.Generic;
using JP.Mytrix.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

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


        [SerializeField, FormerlySerializedAs("patterns")]
        public List<TetrinoPattern> Patterns;

        public void AddPattern()
        {
            if(Patterns == null) Patterns = new List<TetrinoPattern>();

            Patterns.Add(new TetrinoPattern(5,5));
        }

        public void RemovePattern(int index)
        {
            if(Patterns == null) return;

            Patterns.RemoveAt(index);
        }
    }
}
