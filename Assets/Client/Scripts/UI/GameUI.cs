using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private UpMenu _upMenu;
    [SerializeField] private CoinsPool _coinsPool;
    [SerializeField] private WorkshopPanel _workshopPanel;
    public UpMenu UpMenu => _upMenu;
    public CoinsPool CoinsPool => _coinsPool;
    public WorkshopPanel WorkshopPanel => _workshopPanel;
}
