using UnityEngine;

public class PostboxBehavior : MonoBehaviour
{
    
    public int TurnHeadStage;
    public int TurnHeadBackStage;

    private Animator animator;
    private DialogueTrigger trigger;

    private void Start()
    {
        animator = GetComponent<Animator>();
        trigger = GetComponent<DialogueTrigger>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange())
        {
            int stage = trigger.GetDialogueStage();
            if (stage == TurnHeadStage)
            {
                animator.SetBool("Looking", true);
            }
            else if(stage == TurnHeadBackStage)
            {
                animator.SetBool("Looking", false);
            }
        }
    }
}