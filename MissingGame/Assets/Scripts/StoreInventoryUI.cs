using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    private StoreInventory inventory;

    private ShopSlot[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = StoreInventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}