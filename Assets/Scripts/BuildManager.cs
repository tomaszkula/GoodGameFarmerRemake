using UnityEngine;

public enum BuildMode
{
    //NORMAL_MODE, DIG_MODE, SET_UP_PLOWED_MODE, PLOW_MODE, PLANT_MODE, COLLECT_MODE
    Normal_Mode, Dig_Mode, Plant_Mode, Fertilize_Mode, Collect_Mode, Plow_Mode, PutOnGrid_Mode
}

public class BuildManager : MonoBehaviour
{
    BuildMode buildMode;
    ShopItem item;
    PlantItem plantItem;

    void Start()
    {
        buildMode = BuildMode.Normal_Mode;
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

    public bool isModeFlexible()
    {
        switch (buildMode)
        {
            case BuildMode.Normal_Mode:
            case BuildMode.Plant_Mode:
            case BuildMode.Fertilize_Mode:
            case BuildMode.Collect_Mode:
            case BuildMode.Plow_Mode:
                return true;

            default:
                return false;
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

    public PlantItem PlantItem
    {
        get
        {
            return plantItem;
        }

        set
        {
            plantItem = value;
        }
    }
}
