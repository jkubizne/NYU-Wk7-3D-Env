using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorPanel : MonoBehaviour
{
    private ElevatorSound _elevator;

    public bool _elevatorCalled = false;
    public bool _canCallElevator = false;

    [SerializeField] public MeshRenderer _callButton;

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
    public void ElevatorControl()
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
