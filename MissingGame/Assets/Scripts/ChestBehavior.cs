using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public List<Item> contents;

    private Animator animator;

    private DialogueManager manager;
    
    private bool isInRange;
    
    private bool isOpen;

    private bool interacted;

    private void Start()
    {
        animator = GetComponent<Animator>();
        manager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                isOpen = true;
                animator.SetBool("IsOpen", true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/SD/WoodChestOpen", transform.position);
                if (contents.Count > 0)
                {
                    animator.SetBool("IsEmpty", false);
                }
                else
                {
                    animator.SetBool("IsEmpty", true);
                }
            }
            else
            {
                if (contents.Count > 0)
                {
                    foreach (Item item in contents)
                    {
                        Inventory.instance.Add(item);
                    }
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SD/WoodChestTake", transform.position);
                    contents.Clear();
                    animator.SetBool("IsOpen", true);
                    animator.SetBool("IsEmpty", true);
                }
                else
                {
                    
                    animator.SetBool("IsOpen", false);
                    animator.SetBool("IsEmpty", true);
                    interacted = true;
                }
            }
        }
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !interacted)
        {
            isInRange = true;
            manager.OpenInteractionBubble(); 
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            manager.CloseInteractionBubble(); 
        }
    }
}
