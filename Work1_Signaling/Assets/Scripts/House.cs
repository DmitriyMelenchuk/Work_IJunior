using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction _signaling;

    public bool _isContainsAlien { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            _signaling?.Invoke();

            _isContainsAlien = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            _signaling?.Invoke();

            _isContainsAlien = false;
        }
    }
}
