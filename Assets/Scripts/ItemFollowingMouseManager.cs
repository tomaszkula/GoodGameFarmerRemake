using UnityEngine;

public class ItemFollowingMouseManager : MonoBehaviour
{
    GridSystem gridSystem;
    BuildManager buildManager;

    GameObject itemFollowingMouse;

    void Start()
    {
        gridSystem = FindObjectOfType<GridSystem>();
        buildManager = FindObjectOfType<BuildManager>();
    }

    void Update()
    {
        if (!itemFollowingMouse) return;

        FollowMouse();
    }

    void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 toGrid = gridSystem.SnapToGrid(hit.point);
            Vector2Int size = buildManager.Item.GetSize();

            Vector3 newPos = gridSystem.SnapToPosition(toGrid, size);
            itemFollowingMouse.gameObject.transform.position = newPos;
        }
    }

    public void SetItemFollowingMouse(GameObject item)
    {
        Destroy(itemFollowingMouse);
        if (!item) return;

        itemFollowingMouse = (GameObject)Instantiate(item, transform.position, transform.rotation);
        foreach (var component in itemFollowingMouse.GetComponents<Component>())
        {
            if (component is Transform) continue;
            Destroy(component);
        }
    }
}
