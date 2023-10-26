using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerBag : UIScreenView
{
    [SerializeField] private UIBagItem _bagItemPrefab;

    private List<UIBagItem> _bagItems = new List<UIBagItem>();

    private bool _isInitialized = false;


    private void BuyItem(ItemDto data)
    {

    }

    public void UpdateBag(List<ItemDto> itemsInBag)
    {
        foreach (var item in _bagItems)
        {
            Destroy(item.gameObject);
        }

        _bagItems.Clear();

        foreach (var item in itemsInBag)
        {
            var bagItem = Instantiate(_bagItemPrefab, transform);
            _bagItems.Add(bagItem);
            bagItem.Init(item, Equip, Sell);
        }
    }

    private void Equip(ItemDto data)
    {
        AppManager.Player.Equip(data);
    }

    private void Sell(ItemDto data)
    {
        if (AppManager.Player.isInRange)
        {
            AppManager.Player.SellItem(data);;
        }
    }
}
