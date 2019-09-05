using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollowingMouse : MonoBehaviour
{
    GridSystem gridSystem;
    GameObject itemFollowingMouse;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        itemFollowingMouse = null;
    }

    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        if (!itemFollowingMouse) return;
    }

    public void SetItemFollowingMouse(GameObject item)
    {
        if (item) itemFollowingMouse = Instantiate(item, transform.position, transform.rotation);
        else Destroy(item);
    }
}
