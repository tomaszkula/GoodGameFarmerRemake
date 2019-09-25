using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCollect : Task
{
    ShopItem item;
    bool destroyOnCollect;

    protected override void Job()
    {
        if (destroyOnCollect)
        {
            Destroy(taskGameObject);
        }
    }

    public void Init(GameObject go, ShopItem item, bool destroyOnCollect)
    {
        taskGameObject = go;
        this.item = item;
        this.destroyOnCollect = destroyOnCollect;
    }
}
