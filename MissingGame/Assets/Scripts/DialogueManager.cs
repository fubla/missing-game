using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator dialogueAnimator;
    public Animator interactionBubbleAnimator;
    public Text nameText;
    public Text dialogueText;
    private Queue<Sentence> sentences;
    private int dialogueStage;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueStage = 1;
        dialogueAnimator.SetBool("IsOpen", true);
        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return true;
        }

        dialogueStage++;
        Sentence sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        return false;
    }

    IEnumerator TypeSentence(Sentence sentence)
    {
        dialogueText.text = "";
        nameText.text = sentence.name;
        foreach (char letter in sentence.text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        dialogueAnimator.SetBool("IsOpen", false);
    }

    public void OpenInteractionBubble()
    {
        interactionBubbleAnimator.SetBool("PopupOpen", true);
    }

    public void CloseInteractionBubble()
    {
        interactionBubbleAnimator.SetBool("PopupOpen", false);
    }

    public int GetDialogueStage()
    {
        return dialogueStage;
    }
   
}
