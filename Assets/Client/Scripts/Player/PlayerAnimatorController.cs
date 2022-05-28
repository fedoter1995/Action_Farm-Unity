using UnityEngine;

public sealed class PlayerAnimatorController : AnimatorController
{

    private int IntMove = Animator.StringToHash("Move");
    private int IntAttack = Animator.StringToHash("Attack");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetMoveFloatValue(float value)
    {
        SetHashValue(IntMove, value);
    }
    public void SetAttackTrigger()
    {
        SetTriggerValue(IntAttack);
    }
 
}
