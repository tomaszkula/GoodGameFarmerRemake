using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPlant : Task
{
    PlantItem plantItem;
    PlowedFieldController pfc;

    public TaskPlant(GameObject go, PlantItem plantItem) : base(go)
    {
        this.plantItem = plantItem;
        pfc = go.GetComponent<PlowedFieldController>();
    }

    protected override void Job()
    {
        pfc.Plant(plantItem);
    }
}
