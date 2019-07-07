using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class ScoreController : MonoBehaviour
    {
        public const int ROW_SCORE = 100;
        public const int TETRIS_BONUS_SCORE = 1000;

        public const float COMBO_DURATION = 2f;

        public int Score => score;
        private int score;

        private float timeScoreAdded;
        private int combo;
            
        public void Initialize()
        {
            score = 0;
            combo = 0;
            timeScoreAdded = Time.realtimeSinceStartup;
        }

        public void RowScored()
        {

        }

        public bool IsInCombo()
        {
            return Time.realtimeSinceStartup > timeScoreAdded + COMBO_DURATION;
        }

        private void TetrinoScored()
        {
        }


    }
}