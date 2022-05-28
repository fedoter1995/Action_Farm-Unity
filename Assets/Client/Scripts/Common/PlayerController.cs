using System;
using UnityEngine;

public abstract class PlayerController : ScriptableObject
{
    protected IPlayerInput _input;
    protected IInputManager _userInput;

    

    public event Action AttackEvent;
    public IInputManager UserInput => _userInput;

    protected void Attack()
    {
        AttackEvent?.Invoke();
    }
    public abstract void Move(float speed, Transform transform);

    public abstract void InitInputs();


}
