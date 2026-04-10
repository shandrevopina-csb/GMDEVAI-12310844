using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour
{
    public Transform goal; 
    public float speed = 3f;
    public float rotSpeed = 3f;
    public float followDistance = 1.5f;

    void Update()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x,transform.position.y,goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        }

        if (Vector3.Distance(transform.position, lookAtGoal) > followDistance)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
