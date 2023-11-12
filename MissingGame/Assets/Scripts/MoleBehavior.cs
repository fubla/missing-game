using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
    public int FightStage;
    public BoxCollider2D blockingCollider;
    public BoxCollider2D thisCollider;
    private GameManager gameManager;
    private Animator animator;
    private DialogueTrigger trigger;
    private PlayerController playerController;

    private bool hasStruck;

    private void Start()
    {
        gameManager = GameManager.instance;
        animator = GetComponent<Animator>();
        trigger = GetComponent<DialogueTrigger>();
        trigger.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange())
        {
            if (playerController == null)
            {
                playerController = gameManager.GetCurrentPlayer().GetComponent<PlayerController>();
            }
            if (playerController.CanAttack())
            {
                trigger.enabled = true;
            }
            int stage = trigger.GetDialogueStage();
            if (stage == FightStage)
            {
                if (playerController.CanAttack() && !hasStruck)
                {
                    playerController.AttackRight();
                    hasStruck = true;
                    animator.SetBool("IsDead", true);
                    blockingCollider.enabled = false;
                }
            }
        }
    }
}