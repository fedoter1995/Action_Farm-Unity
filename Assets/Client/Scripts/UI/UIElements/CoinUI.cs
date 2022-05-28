using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class CoinUI : MonoBehaviour
{
    private Animation animationClip;
    
    private object sender;
    private object seller;
    private int price;

    private void Awake()
    {
        animationClip = GetComponent<Animation>();
    }


    public void DropCoin(object sender, object seller, int price)
    {
        this.price = price;
        this.sender = sender;
        this.seller = seller;
        DropCoinsAnimation();
    }

    public void HideCoin()
    {
        Bank.AddCoins(sender, price);
        gameObject.SetActive(false);
    }

    private void DropCoinsAnimation()
    {
        animationClip.Play();
    }

}
