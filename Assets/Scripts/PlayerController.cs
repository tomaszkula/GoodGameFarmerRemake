using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 8f;

    public bool IsMoving { get; set; }

    public IEnumerator MovePlayer(Vector3 pos)
    {
        Vector3 newPos = new Vector3(pos.x, transform.position.y, pos.z);
        Vector3 xEnd = newPos;
        xEnd.z = transform.position.z;

        transform.LookAt(xEnd);
        while(Mathf.Abs(xEnd.x - transform.position.x) > Mathf.Epsilon)
        {
            if (!IsMoving) yield break;

            transform.position = Vector3.MoveTowards(transform.position, xEnd, movementSpeed * Time.deltaTime);
            yield return null;
        }

        transform.LookAt(newPos);
        while (Mathf.Abs(newPos.z - transform.position.z) > Mathf.Epsilon)
        {
            if (!IsMoving) yield break;

            transform.position = Vector3.MoveTowards(transform.position, newPos, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
