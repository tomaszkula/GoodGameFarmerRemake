using UnityEngine;
using UnityEngine.EventSystems;

public class FarmTerrain : MonoBehaviour
{
    GridSystem gridSystem;
    BuildManager buildManager;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        buildManager = FindObjectOfType<BuildManager>();
    }

    void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (buildManager.BuildMode == BuildMode.SET_UP_PLOWED_MODE) SetUpPlowed(hit.point);
        }
    }

    void SetUpPlowed(Vector3 point)
    {
        BuildItemOnGrid(point);
    }

    void BuildItemOnGrid(Vector3 point)
    {
        Vector3 pos = gridSystem.SnapToGrid(point);
        Vector2 size = buildManager.Item.GetSize();
        if (!CanBuild(pos, size)) return;

        Vector3 newPos = gridSystem.SnapToPosition(pos, size);
        GameObject item = (GameObject)Instantiate(buildManager.Item.GetItemPrefab(), newPos, Quaternion.identity);
        item.transform.parent = gridSystem.transform;
        FillGrid(pos, size, item);
    }

    bool CanBuild(Vector3 pos, Vector2 size)
    {
        for (int x = (int)(pos.x); x < pos.x + (int)(size.x); x++)
        {
            for (int z = (int)(pos.z); z > pos.z - (int)(size.y); z--)
            {
                if (!gridSystem.IsNodeFree(x, z)) return false;
            }
        }
        return true;
    }

    void FillGrid(Vector3 pos, Vector2 size, GameObject go)
    {
        for (int x = (int)(pos.x); x < pos.x + (int)(size.x); x++)
        {
            for (int z = (int)(pos.z); z > pos.z - (int)(size.y); z--)
            {
                gridSystem.FillGrid(x, z, go);
            }
        }
    }
}
