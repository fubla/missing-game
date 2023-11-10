using System.Collections.Generic;
using UnityEngine;

public class StoreInventory : MonoBehaviour
{
    #region Singleton

    public static StoreInventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of StoreInventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;
   
    public int space = 8;
   
    public List<Item> items;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Inventory full!");
            return false;
        }
      
        items.Add(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}