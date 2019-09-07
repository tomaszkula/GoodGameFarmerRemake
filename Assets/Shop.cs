using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject itemHolderPrefab;
    [SerializeField] Transform grid;

    [Header("Item Lists")]
    [SerializeField] List<ShopItem> plants;

    void Start()
    {
        FillShop();
    }

    void FillShop()
    {
        foreach (ShopItem plant in plants)
        {
            GameObject itemHolder = (GameObject)Instantiate(itemHolderPrefab, grid);
            ItemHolder holderScript = itemHolder.GetComponent<ItemHolder>();

            holderScript.SetItemName(plant.GetItemName());
            holderScript.SetItemExp(plant.GetItemExp());
            holderScript.SetItemPrize(plant.GetItemPrize());
            holderScript.SetItemAdditionalPrize(plant.GetItemAdditionalPrize());
            holderScript.SetItemCost(plant.GetItemCost());
        }
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
