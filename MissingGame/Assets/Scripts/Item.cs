using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public int price = 0;


    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
