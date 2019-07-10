using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoContainer : DisposableData
    {
        private int position;
        public int Position => position;

        private Tetrino tetrino;
        public Tetrino Tetrino => tetrino;

        public delegate void PositionUpdateDelegate(int position);
        public event PositionUpdateDelegate OnPositionUpdateEvent;

        public TetrinoContainer (int position, Tetrino config)
        {
            this.position = position;
            this.tetrino = config;
        }

        public void MoveUp()
        {
            position--;

            if (position < 0)
            {
                Dispose();
                return;
            }

            DispatchOnPositionUpdateEvent();
        }

        private void DispatchOnPositionUpdateEvent()
        {
            if (OnPositionUpdateEvent != null)
                OnPositionUpdateEvent(position);
        }
    }
}
