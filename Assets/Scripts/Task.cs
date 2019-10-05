using System.Collections;
using UnityEngine;

public enum TaskType
{
    PlantTask, CollectTask, PlowTask
}

public abstract class Task
{
    protected GameObject taskGameObject;
    GameObject playerPositionTarget;

    GridSystem gridSystem;
    PlayerController playerController;

    public bool IsDoing { get; set; }

    public Task(GameObject go)
    {
        gridSystem = Object.FindObjectOfType<GridSystem>();
        playerController = Object.FindObjectOfType<PlayerController>();

        playerPositionTarget = taskGameObject = go;
    }

    public IEnumerator DoTask()
    {
        if (!IsDoing) yield break;
        playerController.IsMoving = true;
        Vector3 posToMove = gridSystem.GetClosestObjectCorner(playerPositionTarget, playerController.gameObject.transform.position);
        yield return playerController.MovePlayer(posToMove);

        if (!IsDoing) yield break;
        Job();
    }

    public GameObject GetTaskGameObject()
    {
        return taskGameObject;
    }

    public void ChangePlayerPositionTarget(GameObject target)
    {
        playerPositionTarget = target;
    }

    public void StopDoingTask()
    {
        IsDoing = false;
        playerController.IsMoving = false;
    }

    public static implicit operator bool(Task task)
    {
        if (task != null) return true;
        return false;
    }

    protected abstract void Job();
}
