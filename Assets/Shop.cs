using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] Transform shopTabsParent;
    [SerializeField] GameObject shopTabHolderPrefab;
    [SerializeField] Transform shopItemsGridParent;
    [SerializeField] GameObject shopItemsGridPrefab;
    [SerializeField] GameObject shopItemHolderPrefab;
    [SerializeField] GameObject leftSlider;
    [SerializeField] GameObject rightSlider;

    [Header("ShopTabs")]
    [SerializeField] List<ShopTab> shopTabs;

    ShopTab currentTab = null;
    int currentPage = 1;

    void Start()
    {
        FillShop();
        OpenTab(shopTabs[0]);
    }

    void FillShop()
    {
        foreach(ShopTab shopTab in shopTabs)
        {
            GameObject shopTabHolder = Instantiate(shopTabHolderPrefab, shopTabsParent);
            ShopTabHolder shopTabHolderScript = shopTabHolder.GetComponent<ShopTabHolder>();
            shopTabHolderScript.SetTabIcon(shopTab.GetShopTabIcon());

            GameObject shopItemsGrid = Instantiate(shopItemsGridPrefab, shopItemsGridParent);
            shopTab.ShopItemsGrid = shopItemsGrid;
            shopItemsGrid.SetActive(false);

            List<ShopItem> shopItems = shopTab.getShopItems();
            foreach(ShopItem shopItem in shopItems)
            {
                GameObject shopItemHolder = (GameObject)Instantiate(shopItemHolderPrefab, shopItemsGrid.transform);
                ShopItemHolder shopItemHolderScript = shopItemHolder.GetComponent<ShopItemHolder>();
                shopItemHolderScript.SetItemMainInfo(shopItem.GetItemName(), shopItem.GetItemIcon());
                shopItemHolderScript.SetItemInfo(shopItem.GetItemExp(), shopItem.GetItemTime(), shopItem.GetItemPrize(), shopItem.GetItemAdditionalPrize());
                shopItemHolderScript.SetItemCost(shopItem.GetItemCoinCost(), shopItem.GetItemDollarCost());

                shopItemHolderScript.SetBuyButtonEvent();
            }

            shopTabHolderScript.SetButtonEvent(OpenTab, shopTab, 1);
        }
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

    void BuyShopItem()
    {

    }

    public void SlideGridView(int side)
    {
        GameObject shopItemsGrid = currentTab.ShopItemsGrid;

        Vector3 newPos = shopItemsGrid.transform.localPosition;
        newPos.y += side * 735f;
        shopItemsGrid.transform.localPosition = newPos;

        currentPage += side;
        CheckSliders();
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
