using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent _activated;
    [SerializeField] private AudioSource _audioSource;

    private float maxVolume = 1f;
    private bool _isActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            _isActivated = true;
            
            if (_isActivated == true)
            {
                _activated?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            _isActivated = false;
            _activated?.Invoke(); 
        }
    }

    private void Update()
    {
        float volume = maxVolume * Time.deltaTime;

        if (_isActivated == true)
        {
            _audioSource.volume += volume;
        }
        else
        {
            _audioSource.volume -= volume;
        }
    }
}
