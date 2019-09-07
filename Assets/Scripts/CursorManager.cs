using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CursorMode
{
    NORMAL_MODE, GRID_MODE, DIG_MODE
}

public class CursorManager : MonoBehaviour
{
    CursorMode mode;

    void Start()
    {
        mode = CursorMode.NORMAL_MODE;
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
}
