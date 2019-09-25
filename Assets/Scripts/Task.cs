using UnityEngine;

public abstract class Task : MonoBehaviour
{
    protected GameObject taskGameObject;

    public void DoTask()
    {
        //move player...
        Job();
    }

    protected abstract void Job();
}
