using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WizardController: MonoBehaviour
{
    public int HandSwordDialogueStage;
    public int TakeSwordDialogueStage;

    private GameManager gameManager;
    private Animator animator;
    private DialogueTrigger trigger;

    private bool soundDrawPlayed;

    private void Start()
    {
        gameManager = GameManager.instance;
        animator = GetComponent<Animator>();
        trigger = GetComponent<DialogueTrigger>();
        soundDrawPlayed = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange())
        {
            int stage = trigger.GetDialogueStage();
            if (stage == HandSwordDialogueStage)
            {
                animator.SetBool("GivingItem", true);
                if(!soundDrawPlayed)
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SD/SwordReceive", transform.position);
                soundDrawPlayed = true;
            }
            else if(stage == TakeSwordDialogueStage)
            {
                gameManager.ActivatePlayerMode(1);
                animator.SetBool("GivingItem", false);
            }
        }
    }
}
