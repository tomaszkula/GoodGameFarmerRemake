using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantController : MonoBehaviour
{
    BuildManager buildManager;
    TasksQueue tasksQueue;

    PlantItem plantItem;
    System.DateTime beginTime, endTime;
    bool destroyOnCollect, collectable = false;

    public void Init(PlantItem plantItem, bool destroyOnCollect = false)
    {
        this.plantItem = plantItem;
        this.destroyOnCollect = destroyOnCollect;
        ResetGrowth();
    }

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        tasksQueue = FindObjectOfType<TasksQueue>();
    }

    void Update()
    {
        if (System.DateTime.Now < endTime || collectable) return;

        collectable = true;
        Debug.Log("collectable");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.isModeFlexible()) return;

        if (collectable)
        {
            buildManager.BuildMode = BuildMode.Collect_Mode;
        }
        else
        {

        }
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.BuildMode == BuildMode.Dig_Mode) Dig();
        else if (buildManager.BuildMode == BuildMode.Collect_Mode) Collect();
    }

    void Dig()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    void Collect()
    {
        if (!collectable) return;

        TaskCollect task = new TaskCollect(gameObject, plantItem, destroyOnCollect);
        tasksQueue.Add(task);
    }

    public void CollectPlant()
    {
        Destroy(gameObject);
        transform.parent.GetComponent<PlowedFieldController>().SetUnplowed();
    }

    public void ResetGrowth()
    {
        beginTime = System.DateTime.Now;
        endTime = beginTime.AddDays(plantItem.GetItemTime().x).AddHours(plantItem.GetItemTime().y).AddMinutes(plantItem.GetItemTime().z);
    }


}
