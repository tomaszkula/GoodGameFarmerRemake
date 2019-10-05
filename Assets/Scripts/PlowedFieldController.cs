using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedFieldController : MonoBehaviour
{
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
        rend = GetComponent<Renderer>();

        Plow();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.isModeFlexible()) return;

        if (IsPlowed)
        {
            if (PlantGO || !buildManager.PlantItem) return;

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

    void OnDestroy()
    {
        Task task;
        if (!tasksQueue || !(task = tasksQueue.IsQueued(gameObject))) return;

        tasksQueue.RemoveTask(task);
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
        tasksQueue.AddTask(task);
    }

    public void Plant(PlantItem plantItem)
    {
        GameObject prefab = plantItem.GetItemPrefab();
        Renderer prefabRend = prefab.GetComponent<Renderer>();
        Vector3 pos = transform.position;
        pos.y = rend.bounds.max.y;
        pos.y += prefabRend.bounds.max.y - prefabRend.bounds.center.y; // position if pivot is object center but it's not propably
        pos.y -= prefabRend.bounds.center.y - transform.position.y; // correction for pivot point;
        PlantGO = Instantiate(prefab, pos, prefab.transform.rotation);
        PlantGO.transform.parent = transform;

        PlantController pc = PlantGO.GetComponent<PlantController>();
        if (!pc) pc = PlantGO.AddComponent<PlantController>();
        pc.Init(plantItem);
    }

    public void Plow()
    {
        IsPlowed = true;
        rend.materials[1].CopyPropertiesFromMaterial(plowedMaterial);
    }

    public void UnPlow()
    {
        IsPlowed = false;
        rend.materials[1].CopyPropertiesFromMaterial(unplowedMaterial);
    }
}
