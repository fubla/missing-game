using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    
    public int FightStage;

    private GameManager gameManager;
    private Animator animator;
    private DialogueTrigger trigger;

    private bool hasStruck;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        trigger = GetComponent<DialogueTrigger>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange())
        {
            PlayerController playerController = gameManager.GetCurrentPlayer().GetComponent<PlayerController>();
            int stage = trigger.GetDialogueStage();
            if (stage == FightStage)
            {
                if (playerController.CanAttack() && !hasStruck)
                {
                    playerController.AttackRight();
                    hasStruck = true;
                    animator.SetBool("IsDead", true);
                }
            }
        }
    }
}