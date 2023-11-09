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
    
    public PlayerController playerController;

    private DialogueManager manager;
    private Animator animator;


    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int stage = manager.GetDialogueStage();
        if (stage == HandSwordDialogueStage)
        {
            animator.SetBool("IsGiving", true);
            
        }
        else if(stage == TakeSwordDialogueStage)
        {
            
        }
    }
}
