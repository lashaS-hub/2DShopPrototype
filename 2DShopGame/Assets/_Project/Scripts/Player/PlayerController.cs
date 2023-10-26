using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(SkinController))]
public class PlayerController : MonoBehaviour
{
    public int Currency { get; set; } = 100;
    public bool isInRange { get; set; }
    private PlayerMovement _playerMovement;
    private SkinController _skinController;

    public List<ItemDto> ItemsInBag { get; private set; } = new List<ItemDto>();
    public List<ItemDto> EquippedItems { get; private set; } = new List<ItemDto>();

    private bool _hasHat;
    private bool _hasOutfit;

    private ItemDto _hat;
    private ItemDto _outfit;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _skinController = GetComponent<SkinController>();

        _playerMovement.SetSkinCallback(_skinController.SetAnimatorValues);
    }

    public void BuyItem(ItemDto data)
    {
        if (Currency < data.Price) return;
        Currency -= data.Price;
        ItemsInBag.Add(data);
        var currency = (UICurrency)AppManager.UIViewManager.FindView(UIViewType.Currency);
        currency.UpdateCurrency();
        UpdateBag();
    }

    private void UpdateBag()
    {
        UIPlayerBag playerBag = (UIPlayerBag)AppManager.UIViewManager.FindView(UIViewType.PlayerBag);
        playerBag.UpdateBag(ItemsInBag);
    }

    public void Equip(ItemDto data)
    {
        switch (data.ItemType)
        {
            case ItemType.Hat:
                if (_hasHat) return;
                _hasHat = true;
                _skinController.SetHat(data.ItemPrefab);
                _hat = data;
                EquippedItems.Add(data);
                break;
            case ItemType.Outfit:
                if (_hasOutfit) return;
                _hasOutfit = true;
                _skinController.SetOutfit(data.ItemPrefab);
                _outfit = data;
                EquippedItems.Add(data);
                break;
        }
    }

    internal void SellItem(ItemDto data)
    {
        Currency += data.Price;
        if (_hasHat && System.Object.ReferenceEquals(_hat, data) )
        {
            _skinController.RemoveHat();
            _hasHat = false;
        }
        if (_hasOutfit && System.Object.ReferenceEquals(_outfit, data))
        {
            _skinController.RemoveOutfit();
            _hasOutfit = false;
        }
        var currency = (UICurrency)AppManager.UIViewManager.FindView(UIViewType.Currency);
        currency.UpdateCurrency();
        ItemsInBag.Remove(data);
        UpdateBag();
    }
}

