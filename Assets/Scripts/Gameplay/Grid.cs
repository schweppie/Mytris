using System.Collections;
using System.Collections.Generic;
using JP.Mytris.Data;
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

        public void DebugDraw()
        {
            for(int gridy = 0; gridy < height; gridy++)
            {
                for(int gridx = 0; gridx < width; gridx++)
                {
                    Vector3 p1 = new Vector3(gridx,gridy, 0);
                    Vector3 p2 = new Vector3(gridx+1, gridy);
                    Vector3 p3 = new Vector3(gridx, gridy+1);
                    Vector3 p4 = new Vector3(gridx+1, gridy+1);;                    

                    Debug.DrawLine(p1, p2, Color.black);
                    Debug.DrawLine(p1, p3, Color.black);
                    Debug.DrawLine(p2, p4, Color.black);
                    Debug.DrawLine(p3, p4, Color.black);
                }
            }
        }

        public bool CanTetrinoFit(Tetrino tetrino)
        {
            TetrinoPattern pattern = tetrino.Pattern;

            for(int gridy = 0; gridy < height; gridy++)
            {
                for(int gridx = 0; gridx < width; gridx++)
                {
                    for(int ty =0 ; ty < pattern.Height; ty++)
                    {
                        for(int tx = 0; tx < pattern.Width; tx++)
                        {

                        }
                    }
                }
            }

            return true;
        }

        public void AddTetrino(Tetrino tetrino)
        {

        }

        public void UpdateBlocks()
        {


        }
    }
}