using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer
{
    public List<ItemDto> Items;

    public DataContainer()
    {
        // Load items
        var itemsPath = "Resources/GameData/Items";
        var itemsData = Resources.LoadAll<ItemScriptableObject>(itemsPath);

        Items = new List<ItemDto>();

        for (int i = 0; i < itemsData.Length; i++)
        {
            Items.Add(new ItemDto(itemsData[i]));
        }

        // Load Characters . . .
    }
}
