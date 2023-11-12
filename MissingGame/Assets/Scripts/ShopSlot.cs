using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ShopSlot : MonoBehaviour
{
    public Image icon;

    public Text notEnoughText;
    //public Button removeButton;
    
    private Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        // removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }

    public void BuyItem()
    {
        List<Item> foundCoins = Inventory.instance.FindAllByName("Coin");
        if (foundCoins.Count >= item.price)
        {
            for (int i = 0; i < item.price; i++)
            {
                Inventory.instance.Remove(foundCoins[i]);
            }
            Inventory.instance.Add(item);
            StoreInventory.instance.Remove(item);
        }
        else
        {
            StartCoroutine(SetTextForTime(1.0f));
        }
    }

    private IEnumerator SetTextForTime(float waitTime)
    {
        notEnoughText.enabled = true;
        yield return new WaitForSeconds(waitTime);
        notEnoughText.enabled = false;
    } 
}