using System;
using UnityEngine;

public class AmbianceTrigger : MonoBehaviour
{
    public enum EmitterAction
    {
        Play, 
        Stop
    }
    
    [Serializable]
    public struct AmbianceInstructions
    {
        public AmbType ambType;
        public EmitterAction action;
        
    }

    [SerializeField] private AmbianceInstructions ambInstructions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (ambInstructions.action)
            {
                case EmitterAction.Play:
                    AmbianceManager.instance.PlayEmitter(ambInstructions.ambType);
                    break;
                case EmitterAction.Stop:
                    AmbianceManager.instance.StopEmitter(ambInstructions.ambType);
                    break;
            }
        }
    }
}
