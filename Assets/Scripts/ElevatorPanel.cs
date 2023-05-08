using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorPanel : MonoBehaviour
{
    private ElevatorSound _elevator;

    private bool _elevatorCalled = false;
    private bool _canCallElevator = false;

    [SerializeField] private MeshRenderer _callButton;

    // Start is called before the first frame update
    void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<ElevatorSound>();

        if (_elevator == null)
        {
            UnityEngine.Debug.LogError("Elevator is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        ElevatorControl();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canCallElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canCallElevator = false;
        }
    }
    private void ElevatorControl()
    {
        if (Input.GetKeyDown(KeyCode.E) && _canCallElevator)
        {
            if (_elevatorCalled == true)
            {
                _callButton.material.color = Color.red;
                _elevatorCalled = false;
            }
            else
            {
                _callButton.material.color = Color.green;
                _elevatorCalled = true;
            }
            _elevator.CallElevator();
        }
    }
}
