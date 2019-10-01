using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("Items Tabs")]
    [SerializeField] List<ShopTab> shopTabs;

    [Header("Holders Prefabs")]
    [SerializeField] Transform shopTabsParent;
    [SerializeField] GameObject shopTabHolderPrefab;
    [Space(10)]
    [SerializeField] Transform shopItemsGridsParent;
    [SerializeField] GameObject shopItemsGridPrefab;
    [SerializeField] GameObject shopItemHolderPrefab;

    [Header("Page Sliders")]
    [SerializeField] GameObject leftSlider;
    [SerializeField] GameObject rightSlider;

    ShopTab currentTab = null;
    int currentPage = 1;

    BuildManager buildManager;
    ItemFollowingMouseManager itemFollowingMouseManager;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        itemFollowingMouseManager = FindObjectOfType<ItemFollowingMouseManager>();

        FillShop();
        OpenTab(shopTabs[0]);
    }

    void FillShop()
    {
        foreach (ShopTab shopTab in shopTabs)
        {
            GameObject shopTabHolder = Instantiate(shopTabHolderPrefab, shopTabsParent);
            ShopTabHolder shopTabHolderScript = shopTabHolder.GetComponent<ShopTabHolder>();
            shopTabHolderScript.SetTabIcon(shopTab.GetShopTabIcon());

            GameObject shopItemsGrid = Instantiate(shopItemsGridPrefab, shopItemsGridsParent);
            shopTab.ShopItemsGrid = shopItemsGrid;
            shopItemsGrid.SetActive(false);

            List<Item> shopItems = shopTab.getShopItems();
            foreach (Item shopItem in shopItems)
            {
                GameObject shopItemHolder = (GameObject)Instantiate(shopItemHolderPrefab, shopItemsGrid.transform);
                ShopItemHolder shopItemHolderScript = shopItemHolder.GetComponent<ShopItemHolder>();
                shopItemHolderScript.SetItemName(shopItem.GetItemName());
                shopItemHolderScript.SetItemIcon(shopItem.GetItemIcon());

                if (shopItem.GetLevelToUnlock() > 1)
                {
                    SetItemLocked(shopItemHolderScript, shopItem);
                }
                else
                {
                    SetItemUnlocked(shopItemHolderScript, shopItem);
                }
            }

            shopTabHolderScript.SetButtonEvent(OpenTab, shopTab, 1);
        }
    }

    void SetItemLocked(ShopItemHolder shopItemHolderScript, Item shopItem)
    {
        shopItemHolderScript.SetLevelToUnlock(shopItem.GetLevelToUnlock());

        shopItemHolderScript.SetLocked();
    }

    void SetItemUnlocked(ShopItemHolder shopItemHolderScript, Item shopItem)
    {
        shopItemHolderScript.SetItemCost(shopItem.GetItemDollarCost(), shopItem.GetItemCoinCost());

        switch (shopItem.GetItemType())
        {
            case ItemType.Grid:
                break;

            case ItemType.Plant:
                SeedsUnlocked(shopItemHolderScript, (PlantItem)shopItem);
                break;
        }

        shopItemHolderScript.SetBuyButtonEvent(BuyShopItem, shopItem);
        shopItemHolderScript.SetUnlocked();
    }

    void SeedsUnlocked(ShopItemHolder shopItemHolderScript, PlantItem plantItem)
    {
        shopItemHolderScript.SetItemExp(plantItem.GetItemExp());
        shopItemHolderScript.SetItemTime(plantItem.GetItemTime());
        shopItemHolderScript.SetItemPrize(plantItem.GetItemPrize());
        shopItemHolderScript.SetItemAdditionalPrize(plantItem.GetItemAdditionalPrize());
    }

    void OpenTab(ShopTab tab = null, int idPage = 1)
    {
        if (currentTab == tab) return;

        if (currentTab != null) currentTab.ShopItemsGrid.SetActive(false);
        if (tab != null) tab.ShopItemsGrid.SetActive(true);
        currentTab = tab;
        currentPage = idPage;

        CheckSliders();
    }

    void CheckSliders()
    {
        if (currentPage > 1) leftSlider.SetActive(true);
        else leftSlider.SetActive(false);

        if (currentPage < currentTab.GetPagesCount()) rightSlider.SetActive(true);
        else rightSlider.SetActive(false);
    }

    void BuyShopItem(Item item)
    {
        switch(item.GetItemType())
        {
            case ItemType.Grid:
                break;

            case ItemType.Plant:
                buildManager.PlantItem = (PlantItem)item;
                buildManager.BuildMode = BuildMode.Plant_Mode;
                itemFollowingMouseManager.SetItemFollowingMouse(null);
                break;
        }

        ExitShop();
    }

    public void SlideGridView(int side)
    {
        GameObject shopItemsGrid = currentTab.ShopItemsGrid;

        Vector3 newPos = shopItemsGrid.transform.localPosition;
        newPos.y += side * 724f;
        shopItemsGrid.transform.localPosition = newPos;

        currentPage += side;
        CheckSliders();
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
