using UnityEngine;

public abstract class AnimatorController : MonoBehaviour
{
    protected Animator animator;

    protected void SetHashValue(int HashValue,float value)
    {
        animator.SetFloat(HashValue, value);
    }
    protected void SetTriggerValue(int HashValue)
    {
        animator.SetTrigger(HashValue);
    }
}
