using JP.Mytris.Data;

namespace JP.Mytrix.Gameplay
{
    public class TetrinoContainer : DisposableData
    {
        private int position;

        private TetrinoConfig config;
        public TetrinoConfig Config => config;

        public delegate void PositionUpdateDelegate(int position);
        public event PositionUpdateDelegate OnPositionUpdateEvent;

        public TetrinoContainer (int position, TetrinoConfig config)
        {
            this.position = position;
            this.config = config;
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
