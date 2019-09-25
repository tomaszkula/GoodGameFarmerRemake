using UnityEngine;

public enum BuildMode
{
    //NORMAL_MODE, DIG_MODE, SET_UP_PLOWED_MODE, PLOW_MODE, PLANT_MODE, COLLECT_MODE
    Normal_Mode, Dig_Mode, Plant_Mode, Collect_Mode, PutOnGrid_Mode
}

public enum BuildModeFlexibility
{
    Flexible, Inflexible
}

public class BuildManager : MonoBehaviour
{
    BuildMode buildMode;
    BuildModeFlexibility buildModeFlexibility;
    ShopItem item;
    SeedsItem seeds;

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

            switch(value) {
                case BuildMode.Normal_Mode:
                    buildModeFlexibility = BuildModeFlexibility.Flexible;
                    break;
            }
        }
    }

    public BuildModeFlexibility BuildModeFlexibility
    {
        get
        {
            return buildModeFlexibility;
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

    public SeedsItem Seeds
    {
        get
        {
            return seeds;
        }

        set
        {
            seeds = value;
        }
    }
}
