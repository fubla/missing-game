using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager manager;

    private bool isInRange = false;

    private bool isOpen = false;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                if (manager.DisplayNextSentence())
                {
                    isOpen = false;
                }
            }
            else
            {
                TriggerDialogue();
                isOpen = true;
            }
        }
    }

    public void TriggerDialogue()
    {
        manager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            manager.EndDialogue();
            isOpen = false;
        }
    }
}