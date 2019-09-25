using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksQueue : MonoBehaviour
{
    TasksQueue tasksQueue;
    Queue<Task> tasks = new Queue<Task>();
    bool running = false, crRunning = false;

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
        while (running)
        {
            Task task = Remove();
            task.DoTask();
            Debug.Log("XD");
            yield return new WaitForSeconds(3f);
        }
        crRunning = false;
    }

    public void Add(Task task)
    {
        tasks.Enqueue(task);

        if(!running)
        {
            running = true;
            if (!crRunning)
            {
                crRunning = true;
                StartCoroutine("Run");
            }
        }
    }

    public Task Remove()
    {
        Task task = tasks.Dequeue();

        if(tasks.Count < 1)
        {
            running = false;
        }

        return task;
    }
}
