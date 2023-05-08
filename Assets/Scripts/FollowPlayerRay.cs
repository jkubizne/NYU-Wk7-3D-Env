using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerRay : MonoBehaviour
{
    public float rotationSpeed = 5f; // speed at which the object rotates
    public float detectionRange = 5f; // range within which the object starts rotating towards the player

    private Transform player; // reference to the player's transform
    private bool playerInRange = false; // flag for whether the player is in range of the object

    private void Start()
    {
        // find the player object by its tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // calculate the direction to the player
        Vector3 direction = player.position - transform.position;

        // cast a ray towards the player to check if the player is in range of the object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            // check if the ray hit the player object and the distance is within the detection range
            if (hit.collider.CompareTag("Player") && hit.distance <= detectionRange)
            {
                playerInRange = true;
            }
            else
            {
                playerInRange = false;
            }
        }
        else
        {
            playerInRange = false;
        }

        // rotate the object towards the player if the player is in range
        if (playerInRange)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
