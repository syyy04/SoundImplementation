using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace _3DGamekitLite.Scripts.CustomScripts.Simon
{
    [CreateAssetMenu(fileName = "EnemyAudio", menuName = "Scriptables/EnemyAudio")]
    public class EnemyAudio : ScriptableObject
    {
        [SerializeField] private EventReference biteAttackEvent, spitAttackEvent, dieEvent, footstepEvent;

        private EventInstance biteAttackEventInstance, spitAttackEventInstance, dieEventInstance, footstepEventInstance;
    
        public void BiteAttackEventPlay(GameObject obj)
        {
            if (biteAttackEvent.IsNull)
            {
                Debug.LogWarning("Event not found: biteAttackEvent");
            }
            else
            {
                biteAttackEventInstance = RuntimeManager.CreateInstance(biteAttackEvent);
                RuntimeManager.AttachInstanceToGameObject(biteAttackEventInstance, obj, obj.GetComponent<Rigidbody>());
                biteAttackEventInstance.start();
                biteAttackEventInstance.release();
            }
        }
    
        public void SpitAttackEventPlay(GameObject obj)
        {
            if (spitAttackEvent.IsNull)
            {
                Debug.LogWarning("Event not found: spitAttackEvent");
            }
            else
            {
                spitAttackEventInstance = RuntimeManager.CreateInstance(spitAttackEvent);
                RuntimeManager.AttachInstanceToGameObject(spitAttackEventInstance, obj, obj.GetComponent<Rigidbody>());
                spitAttackEventInstance.start();
                spitAttackEventInstance.release();
            }
        }
    
        public void DieEventPlay(GameObject obj)
        {
            if (dieEvent.IsNull)
            {
                Debug.LogWarning("Event not found: dieEvent");
            }
            else
            {
                dieEventInstance = RuntimeManager.CreateInstance(dieEvent);
                RuntimeManager.AttachInstanceToGameObject(dieEventInstance, obj, obj.GetComponent<Rigidbody>());
                dieEventInstance.start();
                dieEventInstance.release();
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
                }
                footstepEventInstance.start();
                footstepEventInstance.release();
            }
        }
    
    
    }
}
