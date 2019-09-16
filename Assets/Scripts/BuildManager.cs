using UnityEngine;

public enum BuildMode
{
    NORMAL_MODE, DIG_MODE, SET_UP_PLOWED_MODE, PLOW_MODE, PLANT_MODE
}

public class BuildManager : MonoBehaviour
{
    BuildMode buildMode;
    ShopItem item;

    void Start()
    {
        buildMode = BuildMode.NORMAL_MODE;
    }

    public BuildMode BuildMode
    {
        get
        {
            return buildMode;
        }

        set
        {
            buildMode = value;
        }
    }

    public ShopItem Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }
}
