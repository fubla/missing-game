using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager manager;

    private bool isInRange;

    private bool isOpen;

    private bool isFinished;

    private int dialogueStage;
   
    [SerializeField] private bool openOnEnter;

    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                dialogueStage = manager.DisplayNextSentence();
                if (dialogueStage == -1)
                {
                    isOpen = false;
                    isFinished = true;
                }
            }
            else if (!isFinished)
            {
                TriggerDialogue();
                isOpen = true;
            }
        }
    }

    public void TriggerDialogue()
    {
        dialogueStage = manager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isFinished)
        {
            isInRange = true;
            if (openOnEnter)
            {
                TriggerDialogue();
                isOpen = true;
            }
            else
            {
                manager.OpenInteractionBubble();    
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            manager.EndDialogue();
            isOpen = false;
            manager.CloseInteractionBubble();
        }
    }

    public bool DialogueIsOpen()
    {
        return isOpen;
    }

    public bool IsInRange()
    {
        return isInRange;
    }

    public int GetDialogueStage()
    {
        return dialogueStage;
    }
}