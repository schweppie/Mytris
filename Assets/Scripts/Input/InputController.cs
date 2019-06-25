using System.Collections.Generic;
using JP.Mytrix.Input.Handlers;
using UnityEngine;

namespace JP.Mytrix.Input
{
    public class InputController : MonoBehaviour
    {
        public delegate void OnInputDelegate(Inputs input);
        public event OnInputDelegate OnInputDownEvent;
        public event OnInputDelegate OnInputUpEvent;
        public event OnInputDelegate OnInputEvent;

        private BaseInputHandler inputHandler;
        private List<Inputs> inputData;

        private void Start()
        {
            inputHandler = new KeyboardInputHandler();
        }

        private void Update()
        {
            inputData = inputHandler.GetInputDown();
            for(int i=0; i<inputData.Count; i++)
                DispatchOnInputDownEvent(inputData[i]);

            inputData = inputHandler.GetInputUp();
            for(int i=0; i<inputData.Count; i++)
                DispatchOnInputUpEvent(inputData[i]);

            inputData = inputHandler.GetInput();
            for(int i=0; i<inputData.Count; i++)
                DispatchOnInputEvent(inputData[i]);

        }

        private void DispatchOnInputDownEvent(Inputs input)
        {
            if(OnInputDownEvent!=null)
                OnInputDownEvent(input);
        }

        private void DispatchOnInputUpEvent(Inputs input)
        {
            if(OnInputUpEvent!=null)
                OnInputUpEvent(input);
        }

        private void DispatchOnInputEvent(Inputs input)
        {
            if(OnInputEvent!=null)
                OnInputEvent(input);
        }
    }
}

