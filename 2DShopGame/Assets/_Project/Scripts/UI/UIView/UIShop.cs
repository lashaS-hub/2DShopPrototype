using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIShop : UIScreenView
{
    [SerializeField] private UIShopItem _shopItemPrefab;

    private bool _isInitialized = false;

    private void OnEnable()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (_isInitialized) return;

        _isInitialized = true;

        var items = AppManager.GameData.Items;

        foreach (var item in items)
        {
            var shopItem = Instantiate(_shopItemPrefab, transform);
            shopItem.Init(item, BuyItem);
        }
    }

    private void BuyItem(ItemDto data)
    {
        AppManager.Player.BuyItem(data);
    }
}
