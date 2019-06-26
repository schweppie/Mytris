using System.Collections.Generic;
using JP.Mytris.Data;
using UnityEngine;

namespace JP.Mytrix.Gameplay
{
    public class Grid
    {
        private Block[,] blockData;

        private int width;
        private int height;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            blockData = new Block[ width, height];
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

                    Color color = blockData[gridx,gridy] != null ? Color.red : Color.blue;

                    Debug.DrawLine(p1, p2, color);
                    Debug.DrawLine(p1, p3, color);
                    Debug.DrawLine(p2, p4, color);
                    Debug.DrawLine(p3, p4, color);
                }
            }
        }

        public bool CanTetrinoFit(Tetrino tetrino, int x, int y, int rotationIndex)
        {
            TetrinoPattern pattern = tetrino.Config.Patterns[rotationIndex % tetrino.Config.Patterns.Count];

            bool canfit = true;

            for(int py = 0; py < pattern.Height; py++)
            {
                for(int px =0; px < pattern.Width; px++)
                {
                    bool patternFilled = pattern.GetValue(px,py);

                    if(x + px < 0 || x + px > width-1 || y + py < 0 || y + py > height-1)
                    {
                        if(patternFilled)
                            canfit = false;

                        continue;
                    }
                    else
                    {
                        if(patternFilled && blockData[x+px, y+py] != null)
                            canfit = false;
                    }
                }
            }

            return canfit;
        }

        public void AddTetrino(Tetrino tetrino)
        {
            TetrinoPattern pattern = tetrino.Config.Patterns[tetrino.PatternIndex];

            int x = tetrino.X;
            int y = tetrino.Y;

            int blockIndex = 0;
            for(int py = 0; py < pattern.Height; py++)
            {
                for(int px =0; px < pattern.Width; px++)
                {
                    if(pattern.GetValue(px,py))
                    {
                        blockData[x+px, y+py] = tetrino.Blocks[blockIndex];
                        blockIndex++;
                    }
                }
            }
        }

        public bool IsRowFull(int row)
        {
            row = Mathf.Max(0, Mathf.Min(row, height-1));

            for(int i=0; i<width; i++)
                if(blockData[i,row] == null)
                    return false;

            return true;
        }

        public void ClearRow(int row)
        {
            
        }
    }
}