using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedField : MonoBehaviour
{
    BuildManager buildManager;

    bool isPlowed;
    GameObject plant;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();

        isPlowed = true;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || 
            buildManager.BuildModeFlexibility != BuildModeFlexibility.Flexible) return;

        if (isPlowed)
        {

        }
        else
        {

        }
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.BuildMode == BuildMode.Dig_Mode) Dig();
        else if (buildManager.BuildMode == BuildMode.Normal_Mode) Plant();
    }

    void Dig()
    {
        Destroy(gameObject);
    }

    void Plant()
    {
        if (plant) return;

        ShopItem shopItem = buildManager.Item;
        plant = Instantiate(shopItem.GetItemPrefab(), transform.position, Quaternion.identity);
        plant.GetComponent<Plant>().Init(shopItem, true);
        plant.transform.parent = transform;
    }
}
