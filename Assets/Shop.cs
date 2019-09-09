using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject itemHolderPrefab;
    [SerializeField] Transform grid;

    [Header("Item Lists")]
    [SerializeField] List<ShopItem> plants;

    [Header("Item Lists View Sliders")]
    [SerializeField] GameObject leftSlider;
    [SerializeField] GameObject rightSlider;

    int currentPage = 1;
    int plantPages;

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
            holderScript.SetItemMainInfo(plant.GetItemName(), plant.GetItemIcon());
            holderScript.SetItemInfo(plant.GetItemExp(), plant.GetItemTime(), plant.GetItemPrize(), plant.GetItemAdditionalPrize());
            holderScript.SetItemCost(plant.GetItemCoinCost(), plant.GetItemDollarCost());
        }

        plantPages = Mathf.CeilToInt(plants.Count / 8.0f);
        CheckSliders();
    }

    public void SlideGridView(int side)
    {
        Vector3 newPos = grid.localPosition;
        newPos.y += side * 735f;
        grid.localPosition = newPos;

        currentPage += side;
        CheckSliders();
    }

    void CheckSliders()
    {
        if (currentPage > 1) leftSlider.SetActive(true);
        else leftSlider.SetActive(false);

        if (currentPage < plantPages) rightSlider.SetActive(true);
        else rightSlider.SetActive(false);
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
