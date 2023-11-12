using UnityEngine;

public class Microwave: MonoBehaviour
{
    private DialogueTrigger trigger;
    public GameObject overlay;
    
    private void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (trigger.IsInRange() && Input.GetKeyDown(KeyCode.E))
        {
            overlay.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (trigger.GetFinished())
        {
            LevelChanger.instance.FadeToNextLevel();
        }
    }
}