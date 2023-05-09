using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private House _house;

    private float _volume = 0.1f;

    private void OnEnable()
    {
        _house.SignalingWorked += OnPlaySound;
        _house.ChangedVolume += OnChangeVolume;
    }

    private void OnDisable()
    {
        _house.SignalingWorked -= OnPlaySound;
        _house.ChangedVolume -= OnChangeVolume;
    }

    private void OnPlaySound()
    {
        _audioSource.Play();
    }

    private void OnChangeVolume()
    {
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        int targetVolume;
        float volumeDelta = _volume * Time.deltaTime;

        while (_house.IsContainsAlien == true)
        {
            targetVolume = 1;

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeDelta);

            yield return null;

        }

        while (_house.IsContainsAlien == false)
        {
            targetVolume = 0;

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeDelta);

            yield return null;
        }
    }
}

