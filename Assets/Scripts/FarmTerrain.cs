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
            if (buildManager.BuildMode == BuildMode.PutOnGrid_Mode) SetUpPlowed(hit.point);
        }
    }

    void SetUpPlowed(Vector3 point)
    {
        BuildItemOnGrid(point);
    }

    void BuildItemOnGrid(Vector3 point)
    {
        Vector2Int size = buildManager.Item.GetSize();
        if (!CanBuild(point, size)) return;

        GameObject prefab = buildManager.Item.GetItemPrefab();
        Vector3 newPos = gridSystem.SnapToGrid(point, prefab, size);

        GameObject item = Instantiate(prefab, newPos, prefab.transform.rotation);
        item.transform.parent = gridSystem.transform;
        FillGrid(point, size, item);
    }

    bool CanBuild(Vector3 pos, Vector2Int size)
    {
        int x = Mathf.FloorToInt(pos.x + 0.5f);
        int z = Mathf.FloorToInt(pos.z + 0.5f);

        for (int i = x; i < x + size.x; i++)
        {
            for (int j = z; j > z - size.y; j--)
            {
                if (!gridSystem.IsNodeFree(i, j))
                {
                    return false;
                }
            }
        }
        return true;
    }

    void FillGrid(Vector3 pos, Vector2 size, GameObject go)
    {
        int x = Mathf.FloorToInt(pos.x + 0.5f);
        int z = Mathf.FloorToInt(pos.z + 0.5f);

        for (int i = x; i < x + size.x; i++)
        {
            for (int j = z; j > z - size.y; j--)
            {
                gridSystem.FillGrid(i, j, go);
            }
        }
    }
}
