using UnityEngine;

namespace JP.Mytris.Data
{
    [System.Serializable]
    public class TetrinoPattern
    {
        private int width;

        public TetrinoPattern(int width, int height)
        {
            data = new bool[width * height];

            this.width = width;
        }

        public void ForceInitialize(int width)
        {
            this.width = width;
        }

        public void SetValue(int x, int y, bool value)
        {
            data[ y * width + x] = value;
        }

        public bool GetValue(int x, int y)
        {
            return data[ y * width + x];
        }

        [SerializeField]
        private bool[] data;
    }
}
