using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedFieldController : MonoBehaviour
{
    [SerializeField] GameObject plowedFieldPaths;
    [SerializeField] Material plowedMaterial;
    [SerializeField] Material unplowedMaterial;

    public GameObject PlantGO { get; set; }
    public bool IsPlowed { get; set; }

    BuildManager buildManager;
    TasksQueue tasksQueue;
    Renderer rend;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        tasksQueue = FindObjectOfType<TasksQueue>();
        rend = plowedFieldPaths.GetComponent<Renderer>();

        Plow();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.isModeFlexible()) return;

        if (IsPlowed)
        {
            if (PlantGO) return;

            buildManager.BuildMode = BuildMode.Plant_Mode;
        }
        else
        {
            buildManager.BuildMode = BuildMode.Plow_Mode;
        }
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.BuildMode == BuildMode.Dig_Mode) Dig();
        else if (buildManager.BuildMode == BuildMode.Plant_Mode) AssignTask(TaskType.PlantTask);
        else if (buildManager.BuildMode == BuildMode.Plow_Mode) AssignTask(TaskType.PlowTask);
    }

    public void Dig()
    {
        Destroy(gameObject);
    }

    public void AssignTask(TaskType taskType)
    {
        if (tasksQueue.IsQueued(gameObject)) return;

        Task task;
        switch (taskType)
        {
            case TaskType.PlantTask:
                if (PlantGO || !IsPlowed) return;
                PlantItem plantItem = buildManager.PlantItem;
                task = new TaskPlant(gameObject, plantItem);
                break;

            case TaskType.PlowTask:
                if (PlantGO || IsPlowed) return;
                task = new TaskPlow(gameObject);
                break;

            default:
                return;
        }
        tasksQueue.Add(task);
    }

    public void Plant(PlantItem plantItem)
    {
        PlantGO = Instantiate(plantItem.GetItemPrefab(), transform.position, Quaternion.identity);
        PlantGO.transform.parent = transform;

        PlantController pc = PlantGO.GetComponent<PlantController>();
        if (!pc) pc = PlantGO.AddComponent<PlantController>();
        pc.Init(plantItem);
    }

    public void Plow()
    {
        IsPlowed = true;
        rend.material = plowedMaterial;
    }

    public void UnPlow()
    {
        IsPlowed = false;
        rend.material = unplowedMaterial;
    }
}
