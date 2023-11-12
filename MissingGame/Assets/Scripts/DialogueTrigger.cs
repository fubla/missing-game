using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public List<Dialogue> dialogues;

    protected DialogueManager manager;

    protected bool isInRange;

    protected bool isOpen;

    protected bool isFinished;

    protected int dialogueStage;
    
    protected int dialogueIndex;

    protected bool isConversationFinished;

    private bool canContinue = true;

    private bool wasInterrupted;

    private int prevStage;
   
    public bool openOnEnter;

    protected virtual void Start()
    {
        manager = DialogueManager.instance;
        dialogueIndex = 0;
        prevStage = 0;
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
            isFinished = true;
            prevStage = dialogueStage;
            
            if (dialogueIndex == dialogues.Count - 1)
            {
                isConversationFinished = true;
                prevStage = 0;
            }
        }
        else if (isFinished)
        {
            if (dialogueIndex + 1 < dialogues.Count)
            {
                TriggerDialogue(++dialogueIndex);
            }
        }
        else
        {
            TriggerDialogue(dialogueIndex);
        }
    }

    public void TriggerDialogue(int index)
    {
        if (dialogueIndex >= dialogues.Count)
        {
            return;
        }
        
        dialogueStage = manager.StartDialogue(dialogues[index]) + prevStage;
        
        isOpen = true;
        isFinished = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player") || isConversationFinished)
        {
            return;
        }
        isInRange = true;
        if (openOnEnter)
        {
            TriggerDialogue(dialogueIndex);
        }
        else
        {
            manager.OpenInteractionBubble();    
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        
        isInRange = false;
        manager.EndDialogue(isConversationFinished);
        isOpen = false;
        manager.CloseInteractionBubble();
    }

    public bool IsInRange()
    {
        return isInRange;
    }

    public int GetDialogueStage()
    {
        return dialogueStage;
    }

    public void SetCanContinue(bool can)
    {
        canContinue = can;
    }

    public bool GetFinished()
    {
        return isFinished;
    }
}
