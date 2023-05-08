using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSound : MonoBehaviour
{
    [SerializeField] private Transform _origin, _target;
    [SerializeField] private float _speed;
    [SerializeField] private AudioSource _startStopAudioSource;
    [SerializeField] private AudioSource _movingAudioSource;
    [SerializeField] private AudioClip _elevatorStartAudioClip;
    [SerializeField] private AudioClip _elevatorMovingAudioClip;
    [SerializeField] private AudioClip _elevatorStopAudioClip;

    private bool _goingDown = false;
    private bool _isMoving = false;

    public void CallElevator()
    {
        if (_isMoving)
        {
            return;
        }

        _goingDown = !_goingDown;

        if (_goingDown == true)
        {
            if (_elevatorStartAudioClip != null)
            {
                _startStopAudioSource.clip = _elevatorStartAudioClip;
                _startStopAudioSource.Play();
            }
        }
        else
        {
            if (_elevatorStopAudioClip != null)
            {
                _startStopAudioSource.clip = _elevatorStopAudioClip;
                _startStopAudioSource.Play();
            }
        }

        _isMoving = true;
        _movingAudioSource.loop = true;
        _movingAudioSource.clip = _elevatorMovingAudioClip;
        _movingAudioSource.Play();
    }

    private void FixedUpdate()
    {
        if (_isMoving == false)
        {
            return;
        }

        if (_goingDown == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _origin.position, _speed * Time.deltaTime);
        }

        if (transform.position == _origin.position || transform.position == _target.position)
        {
            _movingAudioSource.Stop();
            _movingAudioSource.loop = false;

            if (_goingDown == true)
            {
                if (_elevatorStopAudioClip != null)
                {
                    _startStopAudioSource.clip = _elevatorStopAudioClip;
                    _startStopAudioSource.Play();
                }
            }
            else
            {
                if (_elevatorStartAudioClip != null)
                {
                    _startStopAudioSource.clip = _elevatorStartAudioClip;
                    _startStopAudioSource.Play();
                }
            }

            _isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
