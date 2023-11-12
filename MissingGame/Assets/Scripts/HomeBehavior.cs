using System.Collections.Generic;
using UnityEngine;

public class HomeBehavior : MonoBehaviour
{
    private DialogueManager manager;
    
    private bool isInRange;
    
    private bool isOpen;

    private bool interacted;

    private void Start()
    {
        manager = DialogueManager.instance;
    }

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
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
