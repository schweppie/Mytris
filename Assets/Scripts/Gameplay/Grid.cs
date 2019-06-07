using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class Grid
    {
        private bool[,] data;

        private List<Block> blocks;

        private int width;
        private int height;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            data = new bool[ width, height];

            blocks = new List<Block>();
        }

        

        public void UpdateBlocks()
        {


        }
    }
}