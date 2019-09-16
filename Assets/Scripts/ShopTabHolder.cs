using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopTabHolder : MonoBehaviour
{
    [SerializeField] Button button;
    public delegate void ButtonDelegate(ShopTab tab, int idPage);

    public void SetTabIcon(Sprite icon)
    {
        button.GetComponent<Image>().sprite = icon;
    }

    public void SetButtonEvent(ButtonDelegate buttonDelegate, ShopTab tab, int idPage)
    {
        button.onClick.AddListener(() => buttonDelegate(tab, idPage));
    }
}
