using Unity.VisualScripting;
using UnityEngine;

public class Enabler : MonoBehaviour
{
    private DialogueTrigger trigger;
    public BoxCollider2D toEnable;
    
    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange() && trigger.GetFinished())
        {
            toEnable.enabled = true;
        }
    }
}