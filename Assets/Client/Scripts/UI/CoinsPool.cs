using UnityEngine;

public class CoinsPool : MonoBehaviour
{
    [SerializeField] CoinUI _coinPrefab;
    [SerializeField] int _coinsCount;
    private CustomTools.Pool<CoinUI> coins;
    void Awake()
    {
        coins = new CustomTools.Pool<CoinUI>(_coinPrefab, _coinsCount, transform, true);
    }
    
    public void GetCoin(object sender, object seller, int price)
    {
        var coin = SpawnCoin(transform.position);
        coin.DropCoin(sender, seller, price);
    }

    private CoinUI SpawnCoin(Vector3 position)
    {
        var coin = coins.GetFreeObject();
        coin.transform.position = position;
        return coin;
    }
}
