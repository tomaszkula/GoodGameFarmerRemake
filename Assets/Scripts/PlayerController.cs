using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 8f;

    bool moving = false;

    public void Move(Vector3 pos)
    {
        moving = true;

        Vector3 newPos = new Vector3(pos.x, transform.position.y, pos.z);
        StartCoroutine(MovePlayer(newPos));
    }

    IEnumerator MovePlayer(Vector3 end)
    {
        Vector3 xEnd = end;
        xEnd.z = transform.position.z;

        transform.LookAt(xEnd);
        while(Mathf.Abs(xEnd.x - transform.position.x) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, xEnd, movementSpeed * Time.deltaTime);
            yield return null;
        }

        transform.LookAt(end);
        while (Mathf.Abs(end.z - transform.position.z) > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, movementSpeed * Time.deltaTime);
            yield return null;
        }
        moving = false;
    }

    public bool IsMoving()
    {
        return moving;
    }
}
