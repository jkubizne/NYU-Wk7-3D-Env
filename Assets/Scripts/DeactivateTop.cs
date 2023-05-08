using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTop : MonoBehaviour
{
    public GameObject ElevatorTop;

        void OnTriggerEnter(Collider other)
        {
                ElevatorTop.SetActive(true);
        }
        void OnTriggerExit(Collider other)
        {
            ElevatorTop.SetActive(false);
        }
}

