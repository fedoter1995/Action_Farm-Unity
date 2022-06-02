public class BackpackSlot : IBackpackSlot
{
    public bool isEmpty => item == null;

    public IBackpackItem item { get; private set; }

    public string itemID => item.Id;

    public void Clear()
    {
        if (isEmpty)
            return;

        item = null;
    }

    public void SetItem(IBackpackItem item)
    {
        if (!isEmpty)
            return;

        this.item = item;
    }
}

