using System.Collections;
using System.Collections.Generic;
using JP.Mytrix.Gameplay;
using UnityEngine;

namespace JP.Mytris.Data
{
    [CreateAssetMenu(menuName = "Data/TetrinoConfig", fileName = "TetrinoConfig")]
    public class TetrinoConfig : ScriptableObject
    {
        public bool[] Pattern = new bool[DataHelper.TETRINO_DIMENSION * DataHelper.TETRINO_DIMENSION];

        public BlockConfig BlockConfig;

        public TetrinoVisualizer TetrinoVisualizer;
    }
}
