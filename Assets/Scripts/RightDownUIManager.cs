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
        buildManager.BuildMode = BuildMode.NORMAL_MODE;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }

    public void SetUpPlowedMode()
    {
        buildManager.Item = plowedField;
        buildManager.BuildMode = BuildMode.SET_UP_PLOWED_MODE;
        itemFollowingMouseManager.SetItemFollowingMouse(plowedField.GetItemPrefab());
    }

    public void DigMode()
    {
        buildManager.BuildMode = BuildMode.DIG_MODE;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }
}
