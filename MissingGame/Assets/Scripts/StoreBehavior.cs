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

    private PlayerController playerController;


    public bool isStoreClosed;

    private void Start()
    {
        manager = DialogueManager.instance;
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        if (playerController == null)
        {
            playerController = gameManager.GetCurrentPlayer().GetComponent<PlayerController>();
        }
        
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                isOpen = true;
                shopScreenAnimator.SetBool("IsOpen", true);
                playerController.SetCanAttack(false);
            }
            else
            {
                isOpen = false;
                shopScreenAnimator.SetBool("IsOpen", false);
                playerController.SetCanAttack(true);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isStoreClosed)
        {
            isInRange = true;
            manager.OpenInteractionBubble(); 
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isStoreClosed)
        {
            isInRange = false;
            playerController.SetCanAttack(true);
            manager.CloseInteractionBubble();
            if (gameManager.HasApplePie())
            {
                LevelChanger.instance.FadeToNextLevel();
            }
        }
    }
}
