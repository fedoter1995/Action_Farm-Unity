using TMPro;
using UnityEngine;

public sealed class CounterCoinsUI : MonoBehaviour
{
    [SerializeField] private Animation _tabAnimation;
    [SerializeField] private Animator _coinIconAnimator;
    [SerializeField] public TextMeshProUGUI text;

    private int IntSpin = Animator.StringToHash("Spin");
    public void ChangeCoins(int coins)
    {
        _tabAnimation.Stop();
        _tabAnimation.Play();
        _coinIconAnimator.SetTrigger(IntSpin);
        text.text = coins.ToString();
    }
}
