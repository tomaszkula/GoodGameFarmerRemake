using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject itemHolderPrefab;

    [Header("Item Lists")]
    [SerializeField] Transform itemsGridsParent;
    [SerializeField] GameObject itemsGrid;
    [SerializeField] List<ShopItemsList> itemsLists = new List<ShopItemsList>();

    [Header("Item Lists View Sliders")]
    [SerializeField] GameObject leftSlider;
    [SerializeField] GameObject rightSlider;

    List<GameObject> grids = new List<GameObject>();
    List<int> pagesCount = new List<int>();
    int currentItemsListId, currentPage;
    

    void Start()
    {
        FillShop();
        OpenTab();
    }

    void FillShop()
    {
        for(int i = 0; i < itemsLists.Count; i++)
        {
            ShopItemsList items = itemsLists[i];

            grids.Add(Instantiate(itemsGrid, itemsGridsParent));
            grids[i].SetActive(false);

            foreach (ShopItem item in items)
            {
                GameObject itemHolder = (GameObject)Instantiate(itemHolderPrefab, grids[i].transform);
                ItemHolder holderScript = itemHolder.GetComponent<ItemHolder>();
                holderScript.SetItemMainInfo(item.GetItemName(), item.GetItemIcon());
                holderScript.SetItemInfo(item.GetItemExp(), item.GetItemTime(), item.GetItemPrize(), item.GetItemAdditionalPrize());
                holderScript.SetItemCost(item.GetItemCoinCost(), item.GetItemDollarCost());
            }

            int pages = Mathf.CeilToInt(items.Count / 8.0f);
            pagesCount.Add(pages);
        }
    }

    void OpenTab(int idList = 0, int idPage = 1)
    {
        Debug.Log(currentItemsListId);
        currentItemsListId = idList;
        currentPage = idPage;

        grids[currentItemsListId].SetActive(true);

        CheckSliders();
    }

    public void SlideGridView(int side)
    {
        Vector3 newPos = grids[currentItemsListId].transform.localPosition;
        newPos.y += side * 735f;
        grids[currentItemsListId].transform.localPosition = newPos;

        currentPage += side;
        CheckSliders();
    }

    void CheckSliders()
    {
        if (currentPage > 1) leftSlider.SetActive(true);
        else leftSlider.SetActive(false);

        if (currentPage < pagesCount[currentItemsListId]) rightSlider.SetActive(true);
        else rightSlider.SetActive(false);
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
    }
}
