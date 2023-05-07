using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private House _house;

    private float _maxVolume = 1f;

    private void Update()
    {
        float volume = _maxVolume * Time.deltaTime;

        if (_house._isContainsAlien == true)
        {
            _audioSource.volume += volume;
        }
        else
        {
            _audioSource.volume -= volume;
        }
    }

    private void OnEnable()
    {
        _house._signaling += PlaySound;
    }

    private void OnDisable()
    {
        _house._signaling -= PlaySound;
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
