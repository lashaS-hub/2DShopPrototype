using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "GameData/ItemData")]
public class ItemScriptableObject : ScriptableObject
{
    public int Id;
    public GameObject ItemPrefab;
    public ItemType ItemType;
    public Sprite ItemImage;
    public int Price;
}
