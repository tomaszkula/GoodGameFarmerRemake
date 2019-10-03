using UnityEngine;

public class TaskCollect : Task
{
    PlantItem plantItem;

    PlantController pc;

    public TaskCollect(GameObject go, PlantItem plantItem) : base(go)
    {
        this.plantItem = plantItem;
        pc = taskGameObject.GetComponent<PlantController>();

        ChangePlayerPositionTarget(go.transform.parent.gameObject);
    }

    protected override void Job()
    {
        pc.Collect();
    }
}
