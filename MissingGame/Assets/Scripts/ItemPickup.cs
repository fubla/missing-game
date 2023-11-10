using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    void Pickup()
    {
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SD/Coins");
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup();
        }
    }
}
