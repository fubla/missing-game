using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FMODSteps : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference stepRef;
    [FormerlySerializedAs("dialogHintRef")] [SerializeField] private FMODUnity.EventReference swordSwingRef;
    public void PlayStep()
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(stepRef);
        //maybe do some ground checking
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
        instance.start();
        instance.release();
        instance.clearHandle();
    }

    public void PlaySwordSwing()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(swordSwingRef,gameObject);
    }
}
