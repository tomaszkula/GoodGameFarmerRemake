using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedField : MonoBehaviour
{
    BuildManager buildManager;

    GameObject plant;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.BuildMode == BuildMode.DIG_MODE) Dig();
        else if (buildManager.BuildMode == BuildMode.PLANT_MODE) Plant();
    }

    void Dig()
    {
        Destroy(gameObject);
    }

    void Plant()
    {
        if (plant) return;

        plant = Instantiate(buildManager.Item.GetItemPrefab(), transform.position, Quaternion.identity);
        plant.transform.parent = transform;
    }
}
