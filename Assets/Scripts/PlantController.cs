using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantController : MonoBehaviour, ICollectable, ITaskable
{
    public System.DateTime BeginTime { get; set; }
    public System.DateTime EndTime { get; set; }
    public bool IsCollectable { get; set; }
    public bool IsTaskQueued { get { return tasksQueue.IsQueued(gameObject); } }

    TasksQueue tasksQueue;

    void Start()
    {
        tasksQueue = FindObjectOfType<TasksQueue>();
    }

    public void AssignTask()
    {
        //TaskCollect task = new TaskCollect(gameObject, plantItem, destroyOnCollect);
        //tasksQueue.Add(task);
    }

    public void Collect()
    {
        Destroy(gameObject);
        //transform.parent.GetComponent<PlowedFieldController>().SetUnplowed();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

/*public class PlantController : MonoBehaviour, ICollectable
{
    public bool IsCollectable { get; set; }
    public System.DateTime BeginTime { get; set; }
    public System.DateTime EndTime { get; set; }

    BuildManager buildManager;
    TasksQueue tasksQueue;

    PlantItem plantItem;
    System.DateTime beginTime, endTime;
    bool destroyOnCollect;

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
        if (System.DateTime.Now < endTime || IsCollectable) return;

        IsCollectable = true;
        Debug.Log("collectable");
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.isModeFlexible()) return;

        if (IsCollectable)
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

        if (buildManager.BuildMode == BuildMode.Dig_Mode) DigMode();
        else if (buildManager.BuildMode == BuildMode.Collect_Mode) CollectMode();
    }

    void DigMode()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    void CollectMode()
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

    public void Collect()
    {
        throw new System.NotImplementedException();
    }
}
*/
