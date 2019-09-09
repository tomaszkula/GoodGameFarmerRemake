using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] Sprite itemIcon;

    [SerializeField] int levelToUnlock;
    [SerializeField] int itemExp;
    [SerializeField] Vector3Int itemTime;
    [SerializeField] int itemPrize;
    [SerializeField] int itemAdditionalPrize;
    [SerializeField] int itemCoinCost;
    [SerializeField] int itemDollarCost;

    public string GetItemName() { return itemName; }

    public Sprite GetItemIcon() { return itemIcon; }

    public int GetLevelToUnlock() { return levelToUnlock; }

    public int GetItemExp() { return itemExp; }

    public Vector3Int GetItemTime() { return itemTime; }

    public int GetItemPrize() { return itemPrize; }

    public int GetItemAdditionalPrize() { return itemAdditionalPrize; }

    public int GetItemCoinCost() { return itemCoinCost; }

    public int GetItemDollarCost() { return itemDollarCost; }
}