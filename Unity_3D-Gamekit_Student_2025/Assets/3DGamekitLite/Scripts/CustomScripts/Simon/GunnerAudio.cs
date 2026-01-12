using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "GunnerAudio", menuName = "Scriptables/GunnerAudio")]
public class GunnerAudio : ScriptableObject
{
    [SerializeField] private EventReference walkEvent, punchAttackEvent, grenadeAttackEvent, attackShieldEvent, takeDamageEvent, dieEvent;
    
    private EventInstance walkEventInstance, punchAttackEventInstance, grenadeAttackEventInstance, attackShieldEventInstance, takeDamageEventInstance, dieEventInstance;

    public void WalkEventPlay(GameObject obj)
    {
        if (walkEvent.IsNull)
        {
            Debug.LogWarning("No walk event!");
        }
        else
        {
            walkEventInstance = RuntimeManager.CreateInstance(walkEvent);
            RuntimeManager.AttachInstanceToGameObject(walkEventInstance, obj, obj.GetComponent<Rigidbody>());
            walkEventInstance.start();
            walkEventInstance.release();
        }
    }

    public void PunchAttackEventPlay(GameObject obj)
    {
        if (punchAttackEvent.IsNull)
        {
            Debug.LogWarning("No punch event!");
        }
        else
        {
            punchAttackEventInstance = RuntimeManager.CreateInstance(punchAttackEvent);
            RuntimeManager.AttachInstanceToGameObject(punchAttackEventInstance, obj, obj.GetComponent<Rigidbody>());
            punchAttackEventInstance.start();
            punchAttackEventInstance.release();
        }
    }

    public void GrenadeAttackEventPlay(GameObject obj)
    {
        if (grenadeAttackEvent.IsNull)
        {
            Debug.LogWarning("No grenade event!");
        }
        else
        {
            grenadeAttackEventInstance = RuntimeManager.CreateInstance(grenadeAttackEvent);
            RuntimeManager.AttachInstanceToGameObject(grenadeAttackEventInstance, obj, obj.GetComponent<Rigidbody>());
            grenadeAttackEventInstance.start();
            grenadeAttackEventInstance.release();
        }
    }
    
    public void AttackShieldEventPlay(GameObject obj)
    {
        if (attackShieldEvent.IsNull)
        {
            Debug.LogWarning("No attack shield event!");
        }
        else
        {
            attackShieldEventInstance = RuntimeManager.CreateInstance(attackShieldEvent);
            RuntimeManager.AttachInstanceToGameObject(attackShieldEventInstance, obj, obj.GetComponent<Rigidbody>());
            attackShieldEventInstance.start();
            attackShieldEventInstance.release();
        }
    }
    
    public void TakeDamageEventPlay(GameObject obj)
    {
        if (takeDamageEvent.IsNull)
        {
            Debug.LogWarning("No take damage event!");
        }
        else
        {
            takeDamageEventInstance = RuntimeManager.CreateInstance(takeDamageEvent);
            RuntimeManager.AttachInstanceToGameObject(takeDamageEventInstance, obj, obj.GetComponent<Rigidbody>());
            takeDamageEventInstance.start();
            takeDamageEventInstance.release();
        }
    }
    
    public void DieEventPlay(GameObject obj)
    {
        if (dieEvent.IsNull)
        {
            Debug.LogWarning("No die event!");
        }
        else
        {
            dieEventInstance = RuntimeManager.CreateInstance(dieEvent);
            RuntimeManager.AttachInstanceToGameObject(dieEventInstance, obj, obj.GetComponent<Rigidbody>());
            dieEventInstance.start();
            dieEventInstance.release();
        }
    }
}
