using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksQueue : MonoBehaviour
{
    TasksQueue tasksQueue;
    Queue<Task> tasks = new Queue<Task>();
    Task currentTask;
    bool running = false;

    void Awake()
    {
        if(tasksQueue)
        {
            Destroy(this);
        }
        else
        {
            tasksQueue = this;
        }
    }

    IEnumerator Run()
    {
        running = true;
        do { 
            currentTask = Remove();

            StartCoroutine(currentTask.DoTask());
            while (currentTask.IsDoing()) { yield return null; }
            currentTask = null;
        } while (tasks.Count > 0);
        running = false;
    }

    public void Add(Task task)
    {
        tasks.Enqueue(task);
        if (!running) StartCoroutine(Run());
    }

    public Task Remove()
    {
        Task task = tasks.Dequeue();
        return task;
    }

    public bool IsQueued(GameObject go)
    {
        foreach(Task task in tasks)
        {
            if (task.GetTaskGameObject() == go) return true;
        }
        if (currentTask != null && currentTask.GetTaskGameObject() == go)
        {
            return true;
        }

        return false;
    }
}
