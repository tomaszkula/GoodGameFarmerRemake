using UnityEngine;
using UnityEngine.EventSystems;

public class PlowedFieldController : MonoBehaviour
{
    [SerializeField] Material plowedMaterial;
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
    }
}
