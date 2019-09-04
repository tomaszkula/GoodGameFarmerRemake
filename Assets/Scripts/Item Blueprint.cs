using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item Blueprint")]
public class ItemBlueprint : ScriptableObject
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Vector2 size;
    [SerializeField] int cost;
    [SerializeField] int exp;

    public GameObject GetItemPrefab() { return itemPrefab; }

    public Vector2 GetSize() { return size; }

    public int GetCost() { return cost; }

    public int GetExp() { return exp; }
}
