using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    GameObject[,] grid;
    int gridSize = 40;

    private void Start()
    {
        grid = new GameObject[gridSize, gridSize];
    }

    public Vector3 SnapToGrid(Vector3 pos)
    {
        Vector3 newPos = new Vector3();
        newPos.x = Mathf.Floor(pos.x + 0.5f);
        newPos.y = pos.y;
        newPos.z = Mathf.Floor(pos.z + 0.5f);
        return newPos;
    }

    public Vector3 SnapToPosition(Vector3 pos, Vector2 size)
    {
        Vector3 newPos = new Vector3();
        newPos.x = pos.x + (size.x - 1) / 2;
        newPos.y = pos.y + (GetComponent<Renderer>().bounds.size.y) / 2;
        newPos.z = pos.z - (size.y - 1) / 2;
        return newPos;
    }

    public void FillGrid(int i, int j, GameObject go)
    {
        if (i < 0 || j < 0 || i >= gridSize || j >= gridSize)
        {
            Debug.LogError("[GridSystem] FillGrid(int, int, GameObject) - Index out of bounds");
            return;
        }

        grid[i, j] = go;
    }

    public bool IsNodeFree(int i, int j)
    {
        if (i < 0 || j < 0 || i >= gridSize || j >= gridSize) return false;
        return !grid[i, j];
    }
}
