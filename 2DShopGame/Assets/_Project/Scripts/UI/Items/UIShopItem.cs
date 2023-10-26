using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceLabel;
    [SerializeField] private Image _image;
    [SerializeField] private Button _buyButton;

    private Action<ItemDto> _callback;
    private ItemDto data;

    private void Start()
    {
        _buyButton.onClick.AddListener(() => _callback?.Invoke(data));
    }

    public void Init(ItemDto itemData, Action<ItemDto> buyCallback)
    {
        if (itemData == null) return;

        _callback = buyCallback;
        _image.sprite = itemData.ItemImage;
        _priceLabel.text = $"price:{itemData.Price}";

        data = itemData;
    }
}
