using TMPro;
using UnityEngine;

public sealed class BackpackUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    public void ChangeBackpackValues(int capacity, int amount)
    {
        text.text = $"{amount}/{capacity}";
    }
}
