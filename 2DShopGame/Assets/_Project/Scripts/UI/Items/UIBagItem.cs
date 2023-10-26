using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIBagItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _equipItem;
    [SerializeField] private Button _sellItem;

    private Action<ItemDto> _equipCallback;
    private Action<ItemDto> _sellCallback;
    private ItemDto data;

    private void Start()
    {
        _equipItem.onClick.AddListener(() => _equipCallback?.Invoke(data));
        _sellItem.onClick.AddListener(() => _sellCallback?.Invoke(data));
    }

    public void Init(ItemDto itemData, Action<ItemDto> equipCallback, Action<ItemDto> sellCallback)
    {
        if (itemData == null) return;

        _sellCallback = sellCallback;
        _equipCallback = equipCallback;
        _image.sprite = itemData.ItemImage;


        data = itemData;
    }
}
