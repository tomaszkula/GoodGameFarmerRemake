using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ShopItemHolder : MonoBehaviour
{
    [Header("Item Name")]
    [SerializeField] TextMeshProUGUI itemNameText;

    [Header("Item Content")]
    [SerializeField] Image itemIconImage;
    [Space(20)]
    [SerializeField] GameObject itemUnlockedInfo;
    [SerializeField] GameObject expInfo;
    [SerializeField] TextMeshProUGUI expInfoText;
    [SerializeField] GameObject timeInfo;
    [SerializeField] TextMeshProUGUI timeInfoText;
    [SerializeField] GameObject prizeInfo;
    [SerializeField] TextMeshProUGUI prizeInfoText;
    [SerializeField] GameObject additionalPrizeInfo;
    [SerializeField] TextMeshProUGUI additionalPrizeInfoText;
    [SerializeField] GameObject dollarCost;
    [SerializeField] TextMeshProUGUI dollarCostText;
    [SerializeField] GameObject coinCost;
    [SerializeField] TextMeshProUGUI coinCostText;
    [Space(20)]
    [SerializeField] GameObject itemLockedInfo;
    [SerializeField] TextMeshProUGUI levelToUnlockText;

    [Header("Buy Button")]
    [SerializeField] Button buyButton;

    public delegate void ButtonDelegate(Item item);

    public void SetItemName(string name) { itemNameText.text = name; }

    public void SetItemIcon(Sprite icon) { itemIconImage.sprite = icon; }

    public void SetItemExp(int exp)
    {
        expInfoText.text = exp.ToString();
    }

    public void SetItemTime(Vector3Int time)
    {
        string timeInfoMessage = "";

        if (time.x > 0) timeInfoMessage += time.x.ToString() + "d ";
        if (time.y > 0) timeInfoMessage += time.y.ToString() + "h ";
        if (time.z > 0) timeInfoMessage += time.z.ToString() + "m ";
        timeInfoMessage.TrimEnd(' ');

        timeInfoText.text = timeInfoMessage;
    }

    public void SetItemPrize(int prize)
    {
        prizeInfoText.text = prize.ToString();
    }

    public void SetItemAdditionalPrize(int additionalPrize)
    {
        if (additionalPrize < 1)
        {
            additionalPrizeInfo.SetActive(false);
        }
        else
        {
            additionalPrizeInfoText.text = additionalPrize.ToString();
        }
    }

    public void SetItemCost(int dollars, int coins)
    {
        SetDollarCost(dollars);
        SetCoinCost(coins);
    }

    void SetDollarCost(int dollars)
    {
        if (dollars < 1)
        {
            dollarCost.SetActive(false);
        }
        else
        {
            dollarCostText.text = dollars.ToString();
        }
    }

    void SetCoinCost(int coins)
    {
        if (coins < 1)
        {
            coinCost.SetActive(false);
        }
        else
        {
            coinCostText.text = coins.ToString();
        }
    }

    public void SetLevelToUnlock(int level)
    {
        levelToUnlockText.text = level.ToString();
    }

    public void SetBuyButtonEvent(ButtonDelegate buttonDelegate, Item item)
    {
        buyButton.onClick.AddListener(() => buttonDelegate(item));
    }

    public void SetLocked()
    {
        itemLockedInfo.SetActive(true);
    }

    public void SetUnlocked()
    {
        itemUnlockedInfo.SetActive(true);
        buyButton.gameObject.SetActive(true);
    }
}