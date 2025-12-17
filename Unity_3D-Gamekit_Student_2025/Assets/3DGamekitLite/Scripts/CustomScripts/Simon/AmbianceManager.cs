using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public enum AmbType
{
    Weather,
    Outside,
    Inside,
}

public class AmbianceManager : MonoBehaviour
{
    public static AmbianceManager instance { get; private set; }

    [SerializeField] private StudioEventEmitter weatherEmitter, outsideEmitter, insideEmitter, pointerEmitter;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetEmitter(AmbType ambType)
    {
        switch (ambType)
        {
            case AmbType.Weather:
                pointerEmitter = weatherEmitter;
                break;

            case AmbType.Inside:
                pointerEmitter = insideEmitter;
                break;

            case AmbType.Outside:
                pointerEmitter = outsideEmitter;
                break;

        }
    }

    public void PlayEmitter(AmbType ambType)
    {
        GetEmitter(ambType);
        if (!pointerEmitter.IsActive)
        {
            pointerEmitter.Play();
        }
        else
        {
            return;
        }
    }

    public void StopEmitter(AmbType ambType)
    {
        GetEmitter(ambType);
        if (pointerEmitter.IsActive)
        {
            pointerEmitter.Stop();
        }
        else
        {
            return;
        }
    }
}
