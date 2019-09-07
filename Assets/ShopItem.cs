using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] int levelToUnlock;
    [SerializeField] int itemExp;
    [SerializeField] int itemPrize;
    [SerializeField] int itemAdditionalPrize;
    [SerializeField] int itemCost;

    public string GetItemName() { return itemName; }

    public int GetLevelToUnlock() { return levelToUnlock; }

    public int GetItemExp() { return itemExp; }

    public int GetItemPrize() { return itemPrize; }

    public int GetItemAdditionalPrize() { return itemAdditionalPrize; }

    public int GetItemCost() { return itemCost; }
}
