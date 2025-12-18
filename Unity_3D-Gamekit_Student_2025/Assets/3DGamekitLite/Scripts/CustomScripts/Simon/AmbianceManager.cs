using FMODUnity;
using UnityEngine;

namespace _3DGamekitLite.Scripts.CustomScripts.Simon
{
    public enum AmbType
    {
        Weather,
        Outside,
        Inside,
    }

    public class AmbianceManager : MonoBehaviour
    {
        // Creating a static variable of this class, which you can get information from, but not write to.
        public static AmbianceManager instance { get; private set; }

        // StudioEventEmitter variables that hold references to our ambiance events, located in child objects of the AmbianceManager parent object.
        [SerializeField] private StudioEventEmitter weatherEmitter, outsideEmitter, insideEmitter, pointerEmitter;

        private void Awake()
        {
            // Singleton pattern setup, makes sure that there are only one instance of this class
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // GetEmitter is a method that points towards the specific ambianceEmitter that we'd like to instruct different actions to
        public void GetEmitter(AmbType ambType)
        {
            // Compares the AmbType that the method receives and the pointerEmitter is initialised with the proper ambianceEmitter.
            switch (ambType)
            {
                case AmbType.Weather:
                    pointerEmitter = weatherEmitter;
                    break;

                case AmbType.Inside:
                    pointerEmitter = insideEmitter;
                    break;

                case AmbType.Outside:
                    pointerEmitter = outsideEmitter;
                    break;

            }
        }

        public void PlayEmitter(AmbType ambType)
        {
            // Runs the GetEmitter with the information/argument stored in the parameter ambType, so that we can easily play the sound using the pointerEmitter
            GetEmitter(ambType);
            
            // Checks if the pointerEmitter is not already active, if true, then we should play it!
            if (!pointerEmitter.IsActive)
            {
                pointerEmitter.Play();
            }
            // If it is active, the return and do nothing...
            else
            {
                return;
            }
        }

        public void StopEmitter(AmbType ambType)
        {
            // Runs the GetEmitter with the information/argument stored in the parameter ambType, so that we can easily stop the sound using the pointerEmitter
            GetEmitter(ambType);
            
            // Checks if the pointerEmitter is active, if true, then we should stop it!
            if (pointerEmitter.IsActive)
            {
                pointerEmitter.Stop();
            }
            // If it is not active, the return and do nothing...
            else
            {
                return;
            }
        }
    }
}