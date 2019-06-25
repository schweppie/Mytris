using System;
using System.Collections.Generic;
using JP.Mytrix.Statemachine.Game;
using JP.Mytrix.Statemachine.Menu;
using UnityEngine;

namespace JP.Mytrix.Flow
{
    public class Locator : MonoBehaviour
    {
        public static Locator Instance;

        [SerializeField]
        private MonoBehaviour[] instances;

        private Dictionary<Type, System.Object> instanceDictionary;

        private MenuStateMachine menuStateMachine = new MenuStateMachine();
        private GameStateMachine gameStateMachine = new GameStateMachine();

        public void Initalize()
        {
            Instance = this;

            instanceDictionary = new Dictionary<Type, System.Object>();

            for(int i=0; i< instances.Length; i++)
                instanceDictionary.Add(instances[i].GetType(), instances[i]);

            instanceDictionary.Add(menuStateMachine.GetType(), menuStateMachine);
            instanceDictionary.Add(gameStateMachine.GetType(), gameStateMachine);
        }

        public T Get<T>() where T : class
        {
            return instanceDictionary[typeof(T)] as T;
        }
    }
}
