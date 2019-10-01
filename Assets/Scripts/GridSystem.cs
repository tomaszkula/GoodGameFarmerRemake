using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    GameObject[,] grid;
    int gridSize = 32;

    void Start()
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

    public Vector3 SnapToPosition(Vector3 pos, Vector2Int size)
    {
        Vector3 newPos = new Vector3();
        newPos.x = pos.x + (size.x - 1) / 2f;
        newPos.y = /*pos.y +*/ (GetComponent<Renderer>().bounds.size.y);
        newPos.z = pos.z - (size.y - 1) / 2f;
        return newPos;
    }

    public Vector2Int GetObjectSize(GameObject go)
    {
        Vector2Int size = new Vector2Int(0, 0);
        bool xFounded = false, yFounded = false;
        for(int i = 0; i < gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                if(!xFounded && grid[i, j] == go)
                {
                    size.x++;
                }

                if(!yFounded && grid[i, j] == go)
                {
                    size.y++;
                    yFounded = true;
                }
            }

            if (!xFounded && size.x > 0) xFounded = true;
            
            if (yFounded) yFounded = false;
        }

        return size;
    }

    public Vector3 GetClosestObjectCorner(GameObject go, Vector3 point)
    {
        Vector2Int size = GetObjectSize(go);
        Vector3 position = go.transform.position;
        Vector3[] corners = new Vector3[4];
        corners[0] = new Vector3(position.x + size.x / 2f, position.y, position.z + size.y / 2f);
        corners[1] = new Vector3(position.x + size.x / 2f, position.y, position.z - size.y / 2f);
        corners[2] = new Vector3(position.x - size.x / 2f, position.y, position.z + size.y / 2f);
        corners[3] = new Vector3(position.x - size.x / 2f, position.y, position.z - size.y / 2f);

        float[] distances = new float[4];
        distances[0] = (corners[0] - point).sqrMagnitude;
        distances[1] = (corners[1] - point).sqrMagnitude;
        distances[2] = (corners[2] - point).sqrMagnitude;
        distances[3] = (corners[3] - point).sqrMagnitude;

        Vector3 closestCorner = corners[0];
        float minDistance = distances[0];
        if (distances[1] < minDistance)
        {
            closestCorner = corners[1];
            minDistance = distances[1];
        }
        if (distances[2] < minDistance)
        {
            closestCorner = corners[2];
            minDistance = distances[2];
        }
        if (distances[3] < minDistance)
        {
            closestCorner = corners[3];
            minDistance = distances[3];
        }

        return closestCorner;
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
