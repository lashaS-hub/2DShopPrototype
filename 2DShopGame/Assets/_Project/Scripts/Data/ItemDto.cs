using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDto
{
    public int Id { get; private set; }
    public GameObject ItemPrefab { get; private set; }
    public ItemType ItemType { get; private set; }
    public Sprite ItemImage { get; private set; }
    public int Price { get; private set; }

    public ItemDto(ItemScriptableObject item)
    {
        Id = item.Id;
        ItemPrefab = item.ItemPrefab;
        ItemType = item.ItemType;
        ItemImage = item.ItemImage;
        Price = item.Price;
    }
}

public enum ItemType
{
    None,
    Hat,
    Outfit
}
