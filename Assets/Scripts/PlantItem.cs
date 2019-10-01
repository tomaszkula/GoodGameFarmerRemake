using UnityEngine;

[CreateAssetMenu(menuName = "Items/PlantItem")]
public class PlantItem : Item
{
    [Header("Plant Info")]
    [SerializeField] int itemExp;
    [SerializeField] Vector3Int itemTime;
    [SerializeField] int itemPrize;
    [SerializeField] int itemAdditionalPrize;

    void OnEnable()
    {
        itemType = ItemType.Plant;
    }

    public int GetItemExp() { return itemExp; }

    public Vector3Int GetItemTime() { return itemTime; }

    public int GetItemPrize() { return itemPrize; }

    public int GetItemAdditionalPrize() { return itemAdditionalPrize; }
}
