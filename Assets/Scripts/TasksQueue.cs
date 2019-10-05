using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksQueue : MonoBehaviour
{
    TasksQueue tasksQueue;
    List<Task> tasks = new List<Task>();

    public bool IsQueueRunning { get; set; }
    public Task CurrentTask { get; set; }
    public Coroutine CurrentTaskCoroutine { get; set; }

    void Awake()
    {
        if (tasksQueue)
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
        IsQueueRunning = true;
        do
        {
            CurrentTask = RemoveTask();
            CurrentTask.IsDoing = true;
            yield return CurrentTaskCoroutine = StartCoroutine(CurrentTask.DoTask());
            Debug.Log("po startcor");
        } while (tasks.Count > 0);
        IsQueueRunning = false;
    }


    public void AddTask(Task task)
    {
        tasks.Add(task);
        if (!IsQueueRunning) StartCoroutine(Run());
    }

    public Task RemoveTask()
    {
        Task task = tasks[0];
        tasks.RemoveAt(0);
        return task;
    }

    public void RemoveTask(Task task)
    {
        if (task == CurrentTask)
        {
            CurrentTask.StopDoingTask();
        }
    }

    public Task IsQueued(GameObject go)
    {
        foreach (Task task in tasks)
        {
            if (task.GetTaskGameObject() == go) return task;
        }

        if (CurrentTask && CurrentTask.GetTaskGameObject() == go) return CurrentTask;

        return null;
    }

    /*TasksQueue tasksQueue;
    Queue<Task> tasks = new Queue<Task>();
    Task currentTask;
    Coroutine currentTaskCoroutine;
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
            currentTask = GetTask();
            currentTaskCoroutine = StartCoroutine(currentTask.DoTask());
            while (currentTask.IsDoing) { yield return null; }
            currentTask = RemoveTask();
        } while (tasks.Count > 0);
        running = false;
    }

    public void AddTask(Task task)
    {
        tasks.Enqueue(task);
        if (!running) StartCoroutine(Run());
    }

    public Task GetTask()
    {
        Task task = tasks.Peek();
        return task;
    }

    public Task RemoveTask()
    {
        Task task = tasks.Dequeue();
        return task;
    }

    public Task RemoveTask(Task task)
    {
        Queue<Task> newTasks = new Queue<Task>();
        for(int i = 0; i < tasks.Count; i++)
        {
            Task t = tasks.Dequeue();
            if (t == task)
            {
                /*if(t == currentTask)
                {
                    StopCoroutine(currentTaskCoroutine);
                    currentTask.IsDoing = false;
                    tasks = newTasks;
                    return null;
                }
                break;
            }
            newTasks.Enqueue(tasks.Peek());
        }
        return null;
    }

    public Task IsQueued(GameObject go)
    {
        foreach(Task task in tasks)
        {
            if (task.GetTaskGameObject() == go) return task;
        }

        return null;
    }*/
}
