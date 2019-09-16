using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemHolder : MonoBehaviour
{
    [Header("Main Info")]
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] Image itemIconImage;

    [Header("Item Info")]
    [SerializeField] GameObject expInfo;
    [SerializeField] TextMeshProUGUI expInfoText;
    [SerializeField] GameObject timeInfo;
    [SerializeField] TextMeshProUGUI timeInfoText;
    [SerializeField] GameObject prizeInfo;
    [SerializeField] TextMeshProUGUI prizeInfoText;
    [SerializeField] GameObject additionalPrizeInfo;
    [SerializeField] TextMeshProUGUI additionalPrizeInfoText;

    [Header("Item Cost")]
    [SerializeField] GameObject coinCost;
    [SerializeField] TextMeshProUGUI coinCostText;
    [SerializeField] GameObject dollarCost;
    [SerializeField] TextMeshProUGUI dollarCostText;

    [Header("Buy Button")]
    [SerializeField] Button buyButton;

    public delegate void ButtonDelegate(ShopItem item);

    public void SetItemMainInfo(string name, Sprite icon)
    {
        itemNameText.text = name;
        itemIconImage.sprite = icon;
    }

    public void SetItemInfo(int exp, Vector3Int time, int prize, int additionalPrize)
    {
        SetExpInfo(exp);
        SetTimeInfo(time);
        SetPrizeInfo(prize);
        SetAdditionalPrizeInfo(additionalPrize);
    }

    public void SetItemCost(int coins, int dollars)
    {
        SetCoinCost(coins);
        SetDollarCost(dollars);
    }

    void SetExpInfo(int exp)
    {
        if (exp < 1)
        {
            Destroy(expInfo);
            return;
        }
        else
        {
            expInfoText.text = exp.ToString();
        }
    }

    void SetTimeInfo(Vector3Int time)
    {
        if (time.x < 1 && time.y < 1 && time.z < 1)
        {
            Destroy(timeInfo);
            return;
        }
        else
        {
            string timeInfoMessage = "";

            if (time.x > 0) timeInfoMessage += time.x.ToString() + "d ";
            if (time.y > 0) timeInfoMessage += time.y.ToString() + "h ";
            if (time.z > 0) timeInfoMessage += time.z.ToString() + "m ";
            timeInfoMessage.TrimEnd(' ');

            timeInfoText.text = timeInfoMessage;
        }
    }

    void SetPrizeInfo(int prize)
    {
        if (prize < 1)
        {
            Destroy(prizeInfo);
            return;
        }
        else
        {
            prizeInfoText.text = prize.ToString();
        }
    }

    void SetAdditionalPrizeInfo(int additionalPrize)
    {
        if (additionalPrize < 1)
        {
            Destroy(additionalPrizeInfo);
            return;
        }
        else
        {
            additionalPrizeInfoText.text = additionalPrize.ToString();
        }
    }

    void SetCoinCost(int coins)
    {
        if (coins < 1)
        {
            Destroy(coinCost);
            return;
        }
        else
        {
            coinCostText.text = coins.ToString();
        }
    }

    void SetDollarCost(int dollars)
    {
        if (dollars < 1)
        {
            Destroy(dollarCost);
            return;
        }
        else
        {
            dollarCostText.text = dollars.ToString();
        }
    }

    public void SetBuyButtonEvent(ButtonDelegate buttonDelegate, ShopItem item)
    {
        buyButton.onClick.AddListener(() => buttonDelegate(item));
    }
}