using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace _3DGamekitLite.Scripts.CustomScripts.Simon
{
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
            
                //Debug.Log("Combo is: " + comboValue);
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
                    case "Marble":
                        footstepEventInstance.setParameterByName("Surface", 0f);
                        break;
                    case "BloodLake":
                        footstepEventInstance.setParameterByName("Surface", 1f);
                        break;
                    default:
                        footstepEventInstance.setParameterByName("Surface", 0f);
                        break;
                }
            
                footstepEventInstance.start();
                footstepEventInstance.release();
            }
        }
        
        public void JumpEventPlay(GameObject obj)
        {
            if (jumpEvent.IsNull)
            {
                Debug.LogWarning("Event not found: jumpEvent");
            }
            else
            {
                jumpEventInstance = RuntimeManager.CreateInstance(jumpEvent);
                RuntimeManager.AttachInstanceToGameObject(jumpEventInstance, obj, obj.GetComponent<Rigidbody>());
                jumpEventInstance.start();
                jumpEventInstance.release();
            }
        }

        public void LandEventPlay(string surfaceTag, GameObject obj)
        {
            if (landEvent.IsNull)
            {
                Debug.LogWarning("Event not found: landEvent");
            }
            else
            {
                landEventInstance = RuntimeManager.CreateInstance(landEvent);
                RuntimeManager.AttachInstanceToGameObject(landEventInstance, obj, obj.GetComponent<Rigidbody>());
                
                // A switch statement that compares the surfaceTag and its content, and sets the Surface parameter with a unique value based on this
                switch (surfaceTag)
                {
                    case "Marble":
                        footstepEventInstance.setParameterByName("Surface", 0f);
                        break;
                    case "BloodLake":
                        footstepEventInstance.setParameterByName("Surface", 1f);
                        break;
                    default:
                        footstepEventInstance.setParameterByName("Surface", 0f);
                        break;
                }
                landEventInstance.start();
                landEventInstance.release();
            }
        }

        public void DamageEventPlay(GameObject obj)
        {
            if (damageEvent.IsNull)
            {
                Debug.LogWarning("Event not found: damageEvent");
            }
            else
            {
                damageEventInstance = RuntimeManager.CreateInstance(damageEvent);
                RuntimeManager.AttachInstanceToGameObject(damageEventInstance, obj, obj.GetComponent<Rigidbody>());
                damageEventInstance.start();
                damageEventInstance.release();
            }
        }
    }
}
