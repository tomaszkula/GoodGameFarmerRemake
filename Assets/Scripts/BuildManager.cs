using UnityEngine;

public class BuildManager : MonoBehaviour
{
    GridSystem gridSystem;
    CursorManager cursorManager;

    GridItemBlueprint buildItemBlueprint;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        cursorManager = FindObjectOfType<CursorManager>();
    }

    void Update()
    {
        if (cursorManager.Mode != CursorMode.GRID_MODE && cursorManager.Mode != CursorMode.DIG_MODE) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject colliderGameObject = hit.collider.gameObject;

                BuildItemOn(colliderGameObject, hit.point);
                DestroyItem(colliderGameObject);
            }
        }
    }

    void BuildItemOn(GameObject go, Vector3 pos)
    {
        if (cursorManager.Mode != CursorMode.GRID_MODE || !go.CompareTag("Farm Terrain")) return;

        Vector3 toGrid = gridSystem.SnapToGrid(pos);
        Vector2 size = buildItemBlueprint.GetSize();
        if (!CanBuild(toGrid, size)) return;

        Vector3 newPos = gridSystem.SnapToPosition(toGrid, size);
        GameObject item = (GameObject)Instantiate(buildItemBlueprint.GetGridItemPrefab(), newPos, Quaternion.identity);
        FillGrid(toGrid, size, item);
    }

    void DestroyItem(GameObject go)
    {
        if (cursorManager.Mode != CursorMode.DIG_MODE || !go.CompareTag("Grid Item")) return;

        Destroy(go);
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

    public GridItemBlueprint GetBuildItemBlueprint()
    {
        return buildItemBlueprint;
    }

    public void SetBuildItemBlueprint(GridItemBlueprint item)
    {
        buildItemBlueprint = item;
    }
}
