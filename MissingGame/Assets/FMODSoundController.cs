using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODSoundController : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter music;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        music.SetParameter("Underground", 1);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        music.SetParameter("Underground", 0);
    }
}
