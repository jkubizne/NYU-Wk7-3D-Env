using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float maxDistance = 10f;
    public float rotationSpeed = 5f;
    public float initialXRotation = 0f;
    public float initialYRotation = 0f;

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = Quaternion.Euler(initialXRotation, initialYRotation, 0f);
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;

        if (direction.magnitude <= maxDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            targetRotation *= initialRotation;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
