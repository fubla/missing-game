namespace DefaultNamespace
{
    public interface IItemContainer
    {
        int ItemCount(string itemID);
        Item Remove(string itemID);
        bool Remove(Item item);
        bool Add(Item item);
        bool IsFull();
    }
}