using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCollect : Task
{
    PlantItem plantItem;
    bool destroyOnCollect;

    public TaskCollect(GameObject go, PlantItem plantItem, bool destroyOnCollect) : base(go)
    {
        this.plantItem = plantItem;
        this.destroyOnCollect = destroyOnCollect;

        ChangePlayerPositionTarget(go.transform.parent.gameObject);
    }

    protected override void Job()
    {
        if (destroyOnCollect)
        {
            PlantController pc = taskGameObject.GetComponent<PlantController>();
            //pc.CollectPlant();
        }
        else
        {
            PlantController pc = taskGameObject.GetComponent<PlantController>();
            //pc.ResetGrowth();
        }
    }
}
