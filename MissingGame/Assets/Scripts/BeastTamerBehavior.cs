using UnityEngine;

public class BeastTamer : MonoBehaviour
{
    public int GiveStage;
    public Item givenItem;
    private DialogueTrigger trigger;
    private PlayerController playerController;

    private bool hasGiven;

    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange())
        {
            int stage = trigger.GetDialogueStage();
            if (stage == GiveStage && !hasGiven)
            {
                Inventory.instance.Add(givenItem);
                hasGiven = true;
            }
        }
    }
}