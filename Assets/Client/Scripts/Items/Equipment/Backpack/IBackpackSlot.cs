public interface IBackpackSlot
{
    bool isEmpty { get; }
    IBackpackItem item { get; }
    string itemID { get; }
    void SetItem(IBackpackItem item);
    void Clear();
}
