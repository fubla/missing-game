using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Singleton

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found!");
            return;
        }
        instance = this;
    }

    #endregion
    
    public Animator dialogueAnimator;
    public Animator interactionBubbleAnimator;
    public Text nameText;
    public Text dialogueText;
    private Queue<Sentence> sentences;
    private int dialogueStage;
    
    protected virtual void Start()
    {
        sentences = new Queue<Sentence>();
        dialogueStage = 0;
    }

    public int StartDialogue(Dialogue dialogue)
    {
        dialogueAnimator.SetBool("IsOpen", true);
        dialogueStage = 0;
        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        return DisplayNextSentence();
    }

    public int DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(true);
            return dialogueStage;
        }

        dialogueStage++;
        Sentence sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        return dialogueStage;
    }

    protected IEnumerator TypeSentence(Sentence sentence)
    {
        dialogueText.text = "";
        nameText.text = sentence.name;
        foreach (char letter in sentence.text)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue(bool wasFinished)
    {
        if (wasFinished)
        {
            dialogueStage = -1;
        }
        dialogueAnimator.SetBool("IsOpen", false);
    }

    public void OpenInteractionBubble()
    {
        interactionBubbleAnimator.SetBool("PopupOpen", true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SD/UI/DialogueHint");
    }

    public void CloseInteractionBubble()
    {
        interactionBubbleAnimator.SetBool("PopupOpen", false);
    }
}
