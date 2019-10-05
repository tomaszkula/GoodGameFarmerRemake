using UnityEngine;
using UnityEngine.EventSystems;

public class PlantController : MonoBehaviour
{
    public PlantItem PlantItem { get; set; }
    public System.DateTime BeginGrowthTime { get; set; }
    public System.DateTime EndGrowthTime { get; set; }
    public bool IsCollectable { get; set; }

    BuildManager buildManager;
    TasksQueue tasksQueue;

    public void Init(PlantItem plantItem)
    {
        PlantItem = plantItem;
        ResetGrowthTime(PlantItem.GetItemTime().x, PlantItem.GetItemTime().y, PlantItem.GetItemTime().z);
    }

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        tasksQueue = FindObjectOfType<TasksQueue>();
    }

    void Update()
    {
        if (IsCollectable || EndGrowthTime == null || System.DateTime.Now < EndGrowthTime) return;

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
            buildManager.BuildMode = BuildMode.Fertilize_Mode;
        }
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.BuildMode == BuildMode.Dig_Mode) Dig();
        else if (buildManager.BuildMode == BuildMode.Collect_Mode) AssignTask(TaskType.CollectTask);
    }

    void OnDestroy()
    {
        Task task;
        if (!tasksQueue || !(task = tasksQueue.IsQueued(gameObject))) return;

        tasksQueue.RemoveTask(task);
    }

    void Dig()
    {
        Destroy(transform.parent.gameObject);
    }

    public void AssignTask(TaskType taskType)
    {
        if (tasksQueue.IsQueued(gameObject)) return;

        Task task;
        switch (taskType)
        {
            case TaskType.CollectTask:
                if (!IsCollectable) return;
                task = new TaskCollect(gameObject, PlantItem);
                break;

            default:
                return;
        }
        tasksQueue.AddTask(task);
    }

    public void Collect()
    {
        transform.parent.GetComponent<PlowedFieldController>().UnPlow();
        Destroy(gameObject);
    }

    void ResetGrowthTime(int days, int hours, int minutes)
    {
        BeginGrowthTime = System.DateTime.Now;
        EndGrowthTime = BeginGrowthTime.AddDays(days).AddHours(hours).AddSeconds(minutes*5);
    }
}
