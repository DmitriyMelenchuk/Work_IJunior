using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    public event UnityAction ThiefEntered;
    public event UnityAction SignalingActivated;

    public bool IsContainsThief { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            IsContainsThief = true;
            ThiefEntered?.Invoke();
            SignalingActivated?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            IsContainsThief = false;
            ThiefEntered?.Invoke();
            SignalingActivated?.Invoke(); 
        }
    }
}
