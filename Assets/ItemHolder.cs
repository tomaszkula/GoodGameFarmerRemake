using UnityEngine;
using TMPro;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemExp;
    [SerializeField] TextMeshProUGUI itemTime;
    [SerializeField] TextMeshProUGUI itemPrize;
    [SerializeField] TextMeshProUGUI itemAdditionalPrize;
    [SerializeField] TextMeshProUGUI itemCost;

    public void SetItemName(string name)
    {
        itemName.text = name;
    }

    public void SetItemExp(int exp)
    {
        itemExp.text = exp.ToString();
    }

    public void SetItemPrize(int prize)
    {
        itemPrize.text = prize.ToString();
    }

    public void SetItemAdditionalPrize(int additionalPrize)
    {
        itemAdditionalPrize.text = additionalPrize.ToString();
    }

    public void SetItemCost(int cost)
    {
        itemCost.text = cost.ToString();
    }
}
