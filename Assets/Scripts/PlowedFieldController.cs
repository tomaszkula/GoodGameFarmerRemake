using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedFieldController : MonoBehaviour, IDiggable, IPlantable, IPlowable, ITaskable
{
    [SerializeField] GameObject plowedFieldPaths;
    [SerializeField] Material plowedMaterial;
    [SerializeField] Material unplowedMaterial;

    public GameObject PlantGO { get; set; }
    public bool IsPlowable { get; set; }
    public bool IsTaskQueued { get { return tasksQueue.IsQueued(gameObject); } }

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

    public void Dig()
    {
        Destroy(gameObject);
    }

    public void Plant(PlantItem plantItem)
    {
        if (PlantGO) return;

        PlantGO = Instantiate(plantItem.GetItemPrefab(), transform.position, Quaternion.identity);
        PlantGO.transform.parent = transform;


        /*PlantController pc = plant.AddComponent<PlantController>();
        pc.Init(plantItem, true);*/
    }

    public void Plow()
    {
        if (!IsPlowable) return;

        IsPlowable = false;
        rend.material = plowedMaterial;
    }

    public void UnPlow()
    {
        if (IsPlowable) return;

        IsPlowable = true;
        rend.material = unplowedMaterial;
    }

    public void AssignTask()
    {
        PlantItem plantItem = buildManager.PlantItem;
        TaskPlant task = new TaskPlant(gameObject, plantItem);
        tasksQueue.Add(task);
    }

    /*[SerializeField] Material plowedMaterial;
    [SerializeField] Material unplowedMaterial;
    [SerializeField] GameObject plowedFieldPaths;

    BuildManager buildManager;
    TasksQueue tasksQueue;
    Renderer rend;

    bool isPlowed;
    GameObject plant;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        tasksQueue = FindObjectOfType<TasksQueue>();
        rend = plowedFieldPaths.GetComponent<Renderer>();

        SetPlowed();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !buildManager.isModeFlexible()) return;

        if (isPlowed)
        {
            if (plant) return;

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
        else if (buildManager.BuildMode == BuildMode.Plant_Mode) Plant();
        else if (buildManager.BuildMode == BuildMode.Plow_Mode) Plow();
    }

    void Dig()
    {
        Destroy(gameObject);
    }

    void Plant()
    {
        if (plant || !isPlowed || tasksQueue.IsQueued(gameObject)) return;

        PlantItem plantItem = buildManager.PlantItem;
        TaskPlant task = new TaskPlant(gameObject, plantItem);
        tasksQueue.Add(task);
    }

    void Plow()
    {
        if (plant || isPlowed || tasksQueue.IsQueued(gameObject)) return;


    }

    public void SetPlant(GameObject plant)
    {
        this.plant = plant;
    }

    public void SetPlowed()
    {
        isPlowed = true;
        rend.material = plowedMaterial;
    }

    public void SetUnplowed()
    {
        if (!isPlowed) return;

        isPlowed = false;
        rend.material = unplowedMaterial;
    }*/
}
