using System.Collections;
using System.Collections.Generic;
using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CreateAssetMenu(menuName = "Data/TetrinoConfig", fileName = "TetrinoConfig")]
    public class TetrinoConfig : ScriptableObject
    {
        public bool[] Pattern = new bool[16];

        public BlockVisualizer VisualizerPrefab;
    }
}
