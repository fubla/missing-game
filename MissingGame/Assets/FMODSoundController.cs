using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODSoundController : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter music;

    [SerializeField] private FMODUnity.EventReference caveSnapRef;
    private FMOD.Studio.EventInstance caveSnap;

    private void Start()
    {
        caveSnap = FMODUnity.RuntimeManager.CreateInstance(caveSnapRef);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        music.SetParameter("Underground", 1);
        caveSnap.start();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        music.SetParameter("Underground", 0);
        caveSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        caveSnap.release();
    }
}
