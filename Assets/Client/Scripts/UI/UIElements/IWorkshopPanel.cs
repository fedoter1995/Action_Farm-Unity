using System;

public interface IWorkshopPanel : IRespondingToPlayerPanel
{
    void TryToBuyItem(Equipment item);
}

