using System;

public interface IRespondingToPlayer
{
    event Action<object, Player> OnPlayerEnterEvent;
    event Action<object> OnPlayerExitEvent;
}
