using UnityEngine;

public class RightDownUIManager : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] ShopItem plowedField;

    BuildManager buildManager;
    ItemFollowingMouseManager itemFollowingMouseManager;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        itemFollowingMouseManager = FindObjectOfType<ItemFollowingMouseManager>();
    }

    public void NormalMode()
    {
        buildManager.BuildMode = BuildMode.Normal_Mode;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }

    public void SetUpPlowedMode()
    {
        buildManager.Item = plowedField;
        buildManager.BuildMode = BuildMode.PutOnGrid_Mode;
        itemFollowingMouseManager.SetItemFollowingMouse(plowedField.GetItemPrefab());
    }

    public void DigMode()
    {
        buildManager.BuildMode = BuildMode.Dig_Mode;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }
}
