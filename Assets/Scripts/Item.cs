using UnityEngine;

public enum ItemType
{
    Grid,
    Seeds
}

public abstract class Item : ScriptableObject
{
    [Header("Item Main Info")]
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemIcon;
    [SerializeField] protected GameObject itemPrefab;
    [SerializeField] protected ItemType itemType;

    [Header("Item Cost")]
    [SerializeField] protected int itemDollarCost;
    [SerializeField] protected int itemCoinCost;

    [Header("Item Availability")]
    [SerializeField] protected int levelToUnlock;

    public string GetItemName() { return itemName; }

    public Sprite GetItemIcon() { return itemIcon; }

    public GameObject GetItemPrefab() { return itemPrefab; }

    public ItemType GetItemType() { return itemType; }

    public int GetItemDollarCost() { return itemDollarCost; }

    public int GetItemCoinCost() { return itemCoinCost; }

    public int GetLevelToUnlock() { return levelToUnlock; }
}
