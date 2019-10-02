using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject collider = hit.collider.gameObject;
                if (buildManager.BuildMode == BuildMode.Dig_Mode) DigMode(collider);
                else if (buildManager.BuildMode == BuildMode.Plant_Mode) PlantMode(collider);
                else if (buildManager.BuildMode == BuildMode.Collect_Mode) CollectMode(collider);
                else if (buildManager.BuildMode == BuildMode.Plow_Mode) PlowMode(collider);
            }
        }
    }

    void DigMode(GameObject go)
    {
        IDiggable iDiggable = go.GetComponent<IDiggable>();
        if (iDiggable == null) return;

        iDiggable.Dig();
    }

    void PlantMode(GameObject go)
    {
        IPlantable iPlantable = go.GetComponent<IPlantable>();
        if (iPlantable == null) return;

        if (!(iPlantable.PlantGO))
        {
            IPlowable iPlowable = go.GetComponent<IPlowable>();
            if (iPlowable != null)
            {
                if (iPlowable.IsPlowable) return;
            }

            if (!IsTaskable(go))
            {
                iPlantable.Plant(buildManager.PlantItem);
            }
        }
    }

    void CollectMode(GameObject go)
    {
        ICollectable iCollectable = go.GetComponent<ICollectable>();
        if (iCollectable == null) return;

        if (iCollectable.IsCollectable)
        {
            if (!IsTaskable(go))
            {
                iCollectable.Collect();
            }
        }
    }

    void PlowMode(GameObject go)
    {
        IPlowable iPlowable = go.GetComponent<IPlowable>();
        if (iPlowable == null) return;
        
        if (iPlowable.IsPlowable)
        {
            if (!IsTaskable(go))
            {
                iPlowable.Plow();
            }
        }
    }

    bool IsTaskable(GameObject go)
    {
        ITaskable i = go.GetComponent<ITaskable>();
        if(i != null)
        {
            if (i.IsTaskQueued) return false;
            else
            {
                i.AssignTask();
                return true;
            }
        }

        return false;
    }
}
