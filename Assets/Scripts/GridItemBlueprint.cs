using UnityEngine;

[CreateAssetMenu(menuName = "Grid Item Blueprint")]
public class GridItemBlueprint : ScriptableObject
{
    [SerializeField] GameObject gridItemPrefab;
    [SerializeField] Vector2 size;
    [SerializeField] int cost;
    [SerializeField] int exp;

    public GameObject GetGridItemPrefab() { return gridItemPrefab; }

    public Vector2 GetSize() { return size; }

    public int GetCost() { return cost; }

    public int GetExp() { return exp; }
}
