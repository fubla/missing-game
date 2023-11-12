using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    public Dialogue dialogue;

    protected QuestManager manager;

    protected bool isInRange;

    protected bool isOpen;

    protected int dialogueStage;
    
    protected virtual void Start()
    {
        manager = QuestManager.instance;
    }

    protected virtual void Update()
    {
        if (!isInRange || !Input.GetKeyDown(KeyCode.E))
        {
            return;
        }
        
        if (isOpen)
        {
            dialogueStage = manager.DisplayNextSentence();
            if (dialogueStage != -1)
            {
                return;
            }
            isOpen = false;
        }
        else
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        dialogueStage = manager.StartDialogue(dialogue);
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        isInRange = true;
        manager.OpenInteractionBubble();    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        isInRange = false;
        manager.EndDialogue(true);
        isOpen = false;
        manager.CloseInteractionBubble();
    }
}