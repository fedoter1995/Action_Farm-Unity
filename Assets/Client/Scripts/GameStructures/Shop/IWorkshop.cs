using System;
using System.Collections.Generic;

public interface IWorkshop : IStore, IRespondingToPlayer
{
    List<Equipment> Assortment { get; }
    string BuyItem(Equipment item);
}

