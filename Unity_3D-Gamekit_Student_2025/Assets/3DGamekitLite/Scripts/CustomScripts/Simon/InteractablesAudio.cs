using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractablesAudio", menuName = "Scriptables/InteractablesAudio")]
public class InteractablesAudio : ScriptableObject
{
    // A private EventReference variable that holds a reference to a specific FMOD event.
    // SerializeField makes the variable visible in the Inspector window.
    [SerializeField] private EventReference pickupHealthEvent, boxDestroyEvent, doorSwitchEvent, pressurePlateEvent;
    

    // A public void method for playing a 2D-oneshot event, specifically the PickupHealth event.
    public void PickupHealthPlay()
    {
        // Calls the method PlayOneShot form the Class RuntimeManager within FMODUnity.
        RuntimeManager.PlayOneShot(pickupHealthEvent);
    }

    public void BoxDestroyPlay(Transform t)
    {
        // Calls the method PlayOneShot with reference to the boxDestroyEvent at the transform's position, which is a Vector3 variable contained in the Transform class.
        RuntimeManager.PlayOneShot(boxDestroyEvent, t.position);
    }

    public void DoorSwitchPlay(Transform t)
    {
        // Same concept as in BoxDestroyPlay method. This 3D-oneshot event is played at the position of the door switch.
        RuntimeManager.PlayOneShot(doorSwitchEvent, t.position);
    }

    public void PressurePlatePlay()
    {
        // Plays the pressure plate event as a 2D-oneshot sound. Same concept as in PickupHealthPlay method.
        RuntimeManager.PlayOneShot(pressurePlateEvent);
    }
}
