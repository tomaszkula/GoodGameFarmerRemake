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
        GameObject plant = GameObject.Instantiate(plantItem.GetItemPrefab(), taskGameObject.transform.position, Quaternion.identity);
        plant.transform.parent = taskGameObject.transform;
        PlantController pc = plant.AddComponent<PlantController>();
        pc.Init(plantItem, true);

        pfc.SetPlant(plant);
    }
}
