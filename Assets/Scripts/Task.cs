using System.Collections;
using UnityEngine;

public abstract class Task
{
    protected GameObject taskGameObject;
    GameObject playerPositionTarget;

    GridSystem gridSystem;
    PlayerController playerController;

    bool doing;

    public Task(GameObject go)
    {
        gridSystem = Object.FindObjectOfType<GridSystem>();
        playerController = Object.FindObjectOfType<PlayerController>();

        playerPositionTarget = taskGameObject = go;
    }

    void MovePlayer()
    {
        Vector3 posToMove = gridSystem.GetClosestObjectCorner(playerPositionTarget, playerController.gameObject.transform.position);
        playerController.Move(posToMove);
    }

    public IEnumerator DoTask()
    {
        doing = true;

        MovePlayer();
        while(playerController.IsMoving()) { yield return null; }

        Job();

        doing = false;
    }

    public bool IsDoing()
    {
        return doing;
    }

    public GameObject GetTaskGameObject()
    {
        return taskGameObject;
    }

    public void ChangePlayerPositionTarget(GameObject target)
    {
        playerPositionTarget = target;
    }

    protected abstract void Job();
}
