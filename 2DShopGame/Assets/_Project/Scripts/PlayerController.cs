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
    private PlayerMovement _playerMovement;
    private SkinController _skinController;

    public List<ItemDto> _itemsInBag { get; private set; } = new List<ItemDto>();
    public List<ItemDto> _equippedItems { get; private set; } = new List<ItemDto>();

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _skinController = GetComponent<SkinController>();

        _playerMovement.SetSkinCallback(_skinController.SetAnimatorValues);
    }

    public void BuyItem(ItemDto data)
    {
        _itemsInBag.Add(data);
        UpdateBag();
    }

    private void UpdateBag()
    {
        UIPlayerBag playerBag = (UIPlayerBag)AppManager.UIViewManager.FindView(UIViewType.PlayerBag);
        playerBag.UpdateBag(_itemsInBag);
    }
}
