public interface IBackpackSlot
{
    bool isEmpty { get; }
    IBackpackItem item { get; }
    int itemID { get; }
    void SetItem(IBackpackItem item);
    void Clear();
}
