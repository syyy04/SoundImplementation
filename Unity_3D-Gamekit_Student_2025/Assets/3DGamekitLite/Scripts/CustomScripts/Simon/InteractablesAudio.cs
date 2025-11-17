using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractablesAudio", menuName = "Scriptables/InteractablesAudio")]
public class InteractablesAudio : ScriptableObject
{
    public EventReference pickupHealthEvent;

    public void PickupHealthPlay()
    {
        RuntimeManager.PlayOneShot(pickupHealthEvent);
    }
    
}
