using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPlow : Task
{
    PlowedFieldController pfc;

    public TaskPlow(GameObject go) : base(go)
    {
        pfc = go.GetComponent<PlowedFieldController>();
    }

    protected override void Job()
    {
        pfc.Plow();
    }
}
