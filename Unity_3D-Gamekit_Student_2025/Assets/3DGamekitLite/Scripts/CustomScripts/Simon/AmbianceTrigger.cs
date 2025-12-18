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

    [SerializeField] private AmbianceInstructions[] ambInstructions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
                }
            }
        }
    }
}
