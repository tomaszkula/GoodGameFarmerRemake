using UnityEngine;

[CreateAssetMenu(menuName = "Items/SeedsItem")]
public class SeedsItem : Item
{
    [Header("Seeds Info")]
    [SerializeField] int itemExp;
    [SerializeField] Vector3Int itemTime;
    [SerializeField] int itemPrize;
    [SerializeField] int itemAdditionalPrize;

    void OnEnable()
    {
        itemType = ItemType.Seeds;
    }

    public int GetItemExp() { return itemExp; }

    public Vector3Int GetItemTime() { return itemTime; }

    public int GetItemPrize() { return itemPrize; }

    public int GetItemAdditionalPrize() { return itemAdditionalPrize; }
}
