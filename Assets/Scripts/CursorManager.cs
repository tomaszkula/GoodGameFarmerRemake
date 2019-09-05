using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorMode
{
    NORMAL, GRID_MODE
}

public class CursorManager : MonoBehaviour
{
    CursorMode mode;

    void Start()
    {
        mode = CursorMode.NORMAL;
    }

    public CursorMode Mode
    {
        get
        {
            return mode;
        }

        set
        {
            mode = value;
        }
    }

    void Update()
    {
        
    }
}
