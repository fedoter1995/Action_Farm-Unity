using System;


public interface IStore
{
    event Action<object,object,int> BarterEvent;
}
