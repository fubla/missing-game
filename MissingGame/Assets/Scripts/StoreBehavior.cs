using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreBehavior : MonoBehaviour
{
    public Animator shopScreenAnimator;

    private DialogueManager manager;
    
    private GameManager gameManager;

    private bool isInRange;
    
    private bool isOpen;

    private bool interacted;

    private void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                isOpen = true;
                shopScreenAnimator.SetBool("IsOpen", true);
            }
            else
            {
                isOpen = false;
                shopScreenAnimator.SetBool("IsOpen", false);
            }
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
            if (gameManager.HasApplePie())
            {
                LevelChanger.instance.FadeToNextLevel();
            }
        }
    }
}
