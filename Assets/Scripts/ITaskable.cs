using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITaskable
{
    bool IsTaskQueued { get; }

    void AssignTask();
}
