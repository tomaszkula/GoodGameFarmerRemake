using UnityEngine;

public class RightDownUIManager : MonoBehaviour
{
    [SerializeField] GridItemBlueprint plowedField;

    BuildManager buildManager;
    CursorManager cursorManager;
    ItemFollowingMouseManager itemFollowingMouseManager;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        itemFollowingMouseManager = FindObjectOfType<ItemFollowingMouseManager>();
    }

    public void NormalMode()
    {
        cursorManager.Mode = CursorMode.NORMAL_MODE;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }

    public void GridMode_PlowedField()
    {
        cursorManager.Mode = CursorMode.GRID_MODE;
        buildManager.SetBuildItemBlueprint(plowedField);
        itemFollowingMouseManager.SetItemFollowingMouse(plowedField.GetGridItemPrefab());
    }

    public void DigMode()
    {
        cursorManager.Mode = CursorMode.DIG_MODE;
        itemFollowingMouseManager.SetItemFollowingMouse(null);
    }
}
