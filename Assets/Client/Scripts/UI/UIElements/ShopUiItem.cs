using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUiItem : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Image _soldIcon;

    private Equipment item;

    public event Action<Equipment> TryToBuyEvent;
    private void Start()
    {
        _button.onClick.AddListener(TryToBuyItem);
    }

    public void SetItem(Equipment item, bool hasItem)
    {
        this.item = item;
        Debug.Log(this.item);
        SetMainIcon(item.GetStats().Icon);
        SetSoldIcon(hasItem);
        SetTitle(item.GetStats().Title);
        SetPrice(item.GetStats().Price, hasItem);

    }
    private void SetTitle(string title)
    {
        _title.text = title;
    }
    private void SetPrice(int price, bool active)
    {
        _price.text = price.ToString();
        _price.gameObject.SetActive(!active);

    }
    private void SetMainIcon(Sprite icon)
    {
        _button.image.sprite = icon;

    }
    private void SetSoldIcon(bool active)
    {
        _soldIcon.gameObject.SetActive(active);
    }

    public void TryToBuyItem()
    {
        TryToBuyEvent?.Invoke(item);
    }
}
