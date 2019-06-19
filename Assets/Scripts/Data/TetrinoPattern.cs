using UnityEngine;

namespace JP.Mytris.Data
{
    [System.Serializable]
    public class TetrinoPattern
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public TetrinoPattern(int width, int height)
        {
            data = new bool[width * height];

            Width = width;
            Height = height;
        }

        public void ForceInitialize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void SetValue(int x, int y, bool value)
        {
            data[ y * Width + x] = value;
        }

        public bool GetValue(int x, int y)
        {
            return data[ y * Width + x];
        }

        [SerializeField]
        private bool[] data;
    }
}
