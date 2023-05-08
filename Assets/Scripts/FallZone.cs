using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallZone : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject FirstPersonController;

    private void OnTriggerEnter(Collider other)
    {

        // Respawn after hitting fall zone
        if (other.CompareTag("Fall Zone"))
        {
            Debug.Log("Player has fallen out of bounds. Resetting position...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}