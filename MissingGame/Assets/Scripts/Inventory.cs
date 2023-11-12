using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
   #region Singleton

   public static Inventory instance;

   private void Awake()
   {
      if (instance != null)
      {
         Debug.LogWarning("More than one instance of Inventory found!");
         return;
      }
      instance = this;
   }

   #endregion

   public delegate void OnItemChanged();

   public OnItemChanged onItemChangedCallback;
   
   public int space = 8;
   
   public List<Item> items = new List<Item>();

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

   public Item FindItemByName(string name)
   {
      return items.Find(item => item.name == name);
   }
   
   public List<Item> FindAllByName(string name)
   {
      return items.FindAll(item => item.name == name);
   }
   
   
}
