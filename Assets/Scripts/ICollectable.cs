using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    bool IsCollectable { get; set; }

    void Collect();
}
