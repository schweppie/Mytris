using System.Collections.Generic;

namespace JP.Mytrix.Input.Handlers
{
    public abstract class BaseInputHandler
    {
        public abstract List<Inputs> GetInputDown();
        public abstract List<Inputs> GetInputUp();
        public abstract List<Inputs> GetInput();
    }
}
