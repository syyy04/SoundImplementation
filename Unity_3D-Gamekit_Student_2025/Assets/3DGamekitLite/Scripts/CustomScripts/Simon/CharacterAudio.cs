using FMOD.Studio;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "CharacterAudio", menuName = "Scriptables/CharacterAudio")]
public class CharacterAudio : ScriptableObject
{
    [SerializeField] private EventReference attackEvent, footstepEvent, jumpEvent, landEvent, damageEvent;

    private EventInstance attackEventInstance, footstepEventInstance, jumpEventInstance, landEventInstance, damageEventInstance;

    public void AttackEventPlay(int comboValue, GameObject obj)
    {
        // Checking if there is no content within the EventReference "attackEvent". If true then warn the user
        if (attackEvent.IsNull)
        {
            Debug.LogWarning("Event not found: attackEvent");
        }
        // If there is content within the EventReference, proceed to do the following
        else
        {
            // Creating a EventInstance based on the information stored in the EventReference attackEvent
            attackEventInstance = RuntimeManager.CreateInstance(attackEvent);
                    
            // Attaches the EventInstance to a specific GameObject determined by our GameObject-parameter called "obj" and its Rigidbody
            RuntimeManager.AttachInstanceToGameObject(attackEventInstance, obj, obj.GetComponent<Rigidbody>());
    
            // Setting a FMOD-parameter with reference to its name and the value passed to the parameter comboValue
            attackEventInstance.setParameterByName("Combo", comboValue);
    
            // Starting/Playing the EventInstance
            attackEventInstance.start();
            
            // Releases the EventInstance resources from memory
            attackEventInstance.release();
            
            Debug.Log("Combo is: " + comboValue);
        }
        
        
        
    }

    public void FootstepEventPlay(string surfaceTag, GameObject obj)
    {
        if (footstepEvent.IsNull)
        {
            Debug.LogWarning("Event not found: footstepEvent");
        }
        else
        {
            footstepEventInstance = RuntimeManager.CreateInstance(footstepEvent);
            RuntimeManager.AttachInstanceToGameObject(footstepEventInstance, obj, obj.GetComponent<Rigidbody>());

            // A switch statement that compares the surfaceTag and its content, and sets the Surface parameter with a unique value based on this
            switch (surfaceTag)
            {
                case "Grass":
                    footstepEventInstance.setParameterByName("Surface", 0f);
                    break;
                case "BloodLake":
                    footstepEventInstance.setParameterByName("Surface", 1f);
                    break;
                default:
                    footstepEventInstance.setParameterByName("Surface", 0f);
                    break;
                
                // TODO: Add more cases as needed for different surface types
            }
            
            footstepEventInstance.start();
            footstepEventInstance.release();
        }
    }
}
