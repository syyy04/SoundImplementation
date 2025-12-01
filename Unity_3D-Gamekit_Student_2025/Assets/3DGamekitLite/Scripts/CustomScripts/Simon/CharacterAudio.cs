using UnityEngine;
using FMODUnity;
using Gamekit3D;

[CreateAssetMenu(fileName = "CharacterAudio", menuName = "Scriptables/CharacterAudio")]
public class CharacterAudio : ScriptableObject
{
    [SerializeField]
    private EventReference attackEvent;

    public void AttackEventPlay(int comboValue)
    {
        Debug.Log("Combo is: " + comboValue);
    }
}
