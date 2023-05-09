using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction SignalingWorked;
    public event UnityAction ChangedVolume;

    public bool IsContainsAlien { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            IsContainsAlien = true;
            SignalingWorked?.Invoke();
            ChangedVolume?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Alien alien))
        {
            IsContainsAlien = false;
            SignalingWorked?.Invoke();
            ChangedVolume?.Invoke(); 
        }
    }
}
