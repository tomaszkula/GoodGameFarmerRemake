using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlowable
{
    bool IsPlowable { get; set; }

    void Plow();
    void UnPlow();
}
