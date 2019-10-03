using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlantable
{
    GameObject PlantGO { get; set; }

    void Plant(PlantItem plantItem);
}
