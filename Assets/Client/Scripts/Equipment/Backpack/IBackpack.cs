public interface IBackpack
{
    int capacity { get; set; }
    bool isFull { get; }

    IBackpackItem GetItem(string itemID);
    IBackpackItem[] GetAllItems();
    IBackpackItem[] GetAllItems(string itemID);

    int GetItemAmount(int itemID);
    bool TryToAddToBackpack(IBackpackItem item);
    void Remoove(int itemID, int amount = 1);
    bool HasItem(int itemID, out IBackpackItem item);
}
