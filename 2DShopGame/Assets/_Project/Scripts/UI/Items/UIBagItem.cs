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

    private Action<ItemDto> _callback;
    private ItemDto data;

    private void Start()
    {
        _equipItem.onClick.AddListener(() => _callback?.Invoke(data));
    }

    public void Init(ItemDto itemData, Action<ItemDto> buyCallback)
    {
        if (itemData == null) return;

        _callback = buyCallback;
        _image.sprite = itemData.ItemImage;

        data = itemData;
    }
}
