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

        itemFollowingMouse = null;
    }

    void Update()
    {
        if (!itemFollowingMouse) return;

        FollowMouse();
    }

    private void FollowMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 toGrid = gridSystem.SnapToGrid(hit.point);
            Vector2 size = buildManager.GetBuildItemBlueprint().GetSize();

            Vector3 newPos = gridSystem.SnapToPosition(toGrid, size);
            itemFollowingMouse.gameObject.transform.position = newPos;
        }
    }

    public void SetItemFollowingMouse(GameObject item)
    {
        Destroy(itemFollowingMouse);
        if (!item) return;

        itemFollowingMouse = (GameObject)Instantiate(item, transform.position, transform.rotation);
        Destroy(itemFollowingMouse.GetComponent<Collider>());
    }
}
