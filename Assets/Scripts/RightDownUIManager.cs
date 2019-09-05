using UnityEngine;

public class RightDownUIManager : MonoBehaviour
{
    [SerializeField] GridItemBlueprint plowedField;

    BuildManager buildManager;
    CursorManager cursorManager;
    //ItemFollowingMouse itemFollowingMouse;

    void Start()
    {
        buildManager = FindObjectOfType<BuildManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        //itemFollowingMouse = FindObjectOfType<ItemFollowingMouse>();
    }

    public void NormalMode()
    {
        cursorManager.Mode = CursorMode.NORMAL;
    }

    public void GridMode_PlowedField()
    {
        cursorManager.Mode = CursorMode.GRID_MODE;
        buildManager.SetGridItemBlueprint(plowedField);
        //itemFollowingMouse.SetItemFollowingMouse(plowedField.GetGridItemPrefab());
    }
}
