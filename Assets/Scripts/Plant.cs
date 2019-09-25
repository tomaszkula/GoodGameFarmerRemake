using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    BuildManager buildManager;
    TasksQueue tasksQueue;

    ShopItem item;
    System.DateTime beginTime, endTime;
    bool destroyOnCollect, collectable = false;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        tasksQueue = FindObjectOfType<TasksQueue>();
    }

    void Update()
    {
        if (System.DateTime.Now < endTime || collectable) return;

        collectable = true;
    }

    void OnMouseEnter()
    {
        if (buildManager.BuildMode != BuildMode.Normal_Mode) return;

        if(collectable)
        {
            if (buildManager.BuildMode != BuildMode.Collect_Mode) buildManager.BuildMode = BuildMode.Collect_Mode;
        }
        else
        {

        }
    }

    void OnMouseUp()
    {
        if (buildManager.BuildMode == BuildMode.Collect_Mode) Collect();
    }

    public void Init(ShopItem shopItem, bool destroyOnCollect = false)
    {
        item = shopItem;
        beginTime = System.DateTime.Now;
        endTime = beginTime.AddDays(shopItem.GetItemTime().x).AddHours(shopItem.GetItemTime().y).AddMinutes(shopItem.GetItemTime().z);

        this.destroyOnCollect = destroyOnCollect;
    }

    void Collect()
    {
        if (!collectable) return;

        TaskCollect task = gameObject.AddComponent<TaskCollect>();
        task.Init(gameObject, item, destroyOnCollect);
        tasksQueue.Add(task);

        //if (destroyOnCollect) Destroy(gameObject);
    }
}
