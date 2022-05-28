using System;
using UnityEngine;
using Architecture;

public class Barn : MonoBehaviour, IStore
{
    public event Action<object, object, int> BarterEvent;

    private void OnTriggerEnter(Collider other)
    {
        var product = other.GetComponent<IHasPrice>();

        if (product != null)
        {
            Selling(product);
            other.gameObject.SetActive(false);
        } 
    }
    private void Selling(IHasPrice product)
    {
        BarterEvent?.Invoke(this, product, product.Price);
    }
}
