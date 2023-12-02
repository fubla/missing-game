using System.Collections.Generic;
using UnityEngine;

public class CastleBehavior : MonoBehaviour
{
    private DialogueManager manager;
    
    private bool isInRange;
    
    private bool isOpen;

    private bool interacted;
    
    private DialogueTrigger trigger;


    private void Start()
    {
        manager = DialogueManager.instance;
        trigger = GetComponent<DialogueTrigger>();
    }

    private void Update()
    {
        if(isInRange && trigger.GetDialogueStage() == -1)
        {
            LevelChanger.instance.FadeToNextLevel();   
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !interacted)
        {
            isInRange = true;
            manager.OpenInteractionBubble(); 
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            manager.CloseInteractionBubble(); 
        }
    }
}
