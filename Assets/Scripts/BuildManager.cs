using UnityEngine;

public class BuildManager : MonoBehaviour
{
    GridSystem gridSystem;
    CursorManager cursorManager;

    GridItemBlueprint gridItemBlueprint;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        cursorManager = FindObjectOfType<CursorManager>();
    }

    void Update()
    {
        if (cursorManager.Mode != CursorMode.GRID_MODE || !gridItemBlueprint) return;

        BuildItemOn();
    }

    void BuildItemOn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 toGrid = gridSystem.SnapToGrid(hit.point);
                Vector2 size = gridItemBlueprint.GetSize();
                if (!CanBuild(toGrid, size)) return;

                Vector3 newPos = gridSystem.SnapToPosition(toGrid, size);
                GameObject item = (GameObject)Instantiate(gridItemBlueprint.GetGridItemPrefab(), newPos, Quaternion.identity);

                for(int x = (int)(toGrid.x); x < toGrid.x + (int)(size.x); x++)
                {
                    for (int z = (int)(toGrid.z); z > toGrid.z - (int)(size.y); z--)
                    {
                        gridSystem.FillGrid(x, z, item);
                    }
                }
            }
        }
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

    public void SetGridItemBlueprint(GridItemBlueprint item)
    {
        gridItemBlueprint = item;
    }
}
