using System.Collections.Generic;
using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace JP.Mytrix.Input.Handlers
{
    public class KeyboardInputHandler : BaseInputHandler
    {
        private List<Inputs> inputs = new List<Inputs>();

        public override List<Inputs> GetInputDown()
        {
            inputs.Clear();

            if(UnityInput.GetKeyDown(KeyCode.W))
                inputs.Add(Inputs.Up);
            if(UnityInput.GetKeyDown(KeyCode.D))
                inputs.Add(Inputs.Right);
            if(UnityInput.GetKeyDown(KeyCode.S))
                inputs.Add(Inputs.Down);
            if(UnityInput.GetKeyDown(KeyCode.A))
                inputs.Add(Inputs.Left);                                

            return inputs;
        }

        public override List<Inputs> GetInputUp()
        {
            inputs.Clear();

            if(UnityInput.GetKeyUp(KeyCode.W))
                inputs.Add(Inputs.Up);
            if(UnityInput.GetKeyUp(KeyCode.D))
                inputs.Add(Inputs.Right);
            if(UnityInput.GetKeyUp(KeyCode.S))
                inputs.Add(Inputs.Down);
            if(UnityInput.GetKeyUp(KeyCode.A))
                inputs.Add(Inputs.Left);                                

            return inputs;
        }       

        public override List<Inputs> GetInput()
        {
            inputs.Clear();

            if(UnityInput.GetKey(KeyCode.W))
                inputs.Add(Inputs.Up);
            if(UnityInput.GetKey(KeyCode.D))
                inputs.Add(Inputs.Right);
            if(UnityInput.GetKey(KeyCode.S))
                inputs.Add(Inputs.Down);
            if(UnityInput.GetKey(KeyCode.A))
                inputs.Add(Inputs.Left);                                

            return inputs;
        }          
    }
}
