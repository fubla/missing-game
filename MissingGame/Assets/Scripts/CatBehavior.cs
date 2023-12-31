using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    
    public int OpenEyesStage;
    public int CloseEyesStage;

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
            if (stage == OpenEyesStage)
            {
                animator.SetBool("Looking", true);
            }
            else if(stage == CloseEyesStage)
            {
                animator.SetBool("Looking", false);
            }
        }
    }
}
