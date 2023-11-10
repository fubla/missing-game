using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Image icon;
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
        Item foundCoin = Inventory.instance.FindItemByName("Coin");
        if (foundCoin)
        {
            Inventory.instance.Remove(foundCoin);
            Inventory.instance.Add(item);
            StoreInventory.instance.Remove(item);
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }
}