using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction SignalingWorked;

    public bool IsContainsAlien { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            SignalingWorked?.Invoke();

            IsContainsAlien = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            SignalingWorked?.Invoke();

            IsContainsAlien = false;
        }
    }
}
