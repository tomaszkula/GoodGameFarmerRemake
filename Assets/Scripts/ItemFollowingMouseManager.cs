using UnityEngine;

public class ItemFollowingMouseManager : MonoBehaviour
{
    [SerializeField] float distance = 10f;

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
        int layerMask = 8;
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.layer != layerMask) continue;

            Vector2Int size = buildManager.Item.GetSize();
            Vector3 newPos = gridSystem.SnapToGrid(hit.point, itemFollowingMouse, size);
            newPos -= Camera.main.transform.forward * distance; // distance from ground (i want to have item following mouse in the foreground)
            itemFollowingMouse.gameObject.transform.position = newPos;
            return;
        }
    }

    public void SetItemFollowingMouse(GameObject item)
    {
        Destroy(itemFollowingMouse);
        if (!item) return;

        itemFollowingMouse = Instantiate(item, transform.position, item.transform.rotation);

        foreach (var component in itemFollowingMouse.GetComponents<Component>())
        {
            if (component is BoxCollider || component is PlowedFieldController)
            {
                Destroy(component);
            }
        }
    }
}
