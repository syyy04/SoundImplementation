using System;
using _3DGamekitLite.Scripts.CustomScripts.Simon;
using UnityEngine;

public class AmbianceTrigger : MonoBehaviour
{
    // Enum for selecting the action that we want the emitter to do!
    public enum EmitterAction
    {
        Play, 
        Stop,
        SetParameter
    }
    
    // A struct that holds information about what ambianceEmitter we'd like to instruct and the specific parameter information needed for updating a parameter.
    [Serializable]
    public struct AmbianceInstructions
    {
        public AmbType ambType;
        public EmitterAction action;
        public string parameterName;
        public float parameterValue;

    }
    // An array of the struct AmbianceInstructions, makes it possible to create multiple instructions to send to the AmbianceManager
    [SerializeField] private AmbianceInstructions[] ambInstructions;

    private void OnTriggerEnter(Collider other)
    {
        // Comparing the other collider and if that collider has a tag that equals to "Player"
        if (other.CompareTag("Player"))
        {
            // A foreach loop creates a variable i for each iteration of the loop, so referencing i will be a shorthand
            foreach (var i in ambInstructions)
            {
                switch (i.action)
                {
                    case EmitterAction.Play:
                        AmbianceManager.instance.PlayEmitter(i.ambType);
                        break;
                    case EmitterAction.Stop:
                        AmbianceManager.instance.StopEmitter(i.ambType);
                        break;
                    case EmitterAction.SetParameter:
                        AmbianceManager.instance.SetParameter(i.ambType, i.parameterName, i.parameterValue);
                        break;
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var i in ambInstructions)
            {
                switch (i.action)
                {
                    case EmitterAction.Play:
                        AmbianceManager.instance.StopEmitter(i.ambType);
                        break;
                    case EmitterAction.Stop:
                        AmbianceManager.instance.StopEmitter(i.ambType);
                        break;
                    case EmitterAction.SetParameter:
                        break;
                }
            }
        }
    }
}
