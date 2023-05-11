using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private House _house;

    private Coroutine _changeVolumeWorks;
    private float _volume = 1;

    private void OnEnable()
    {
        _house.ThiefEntered += OnPlaySound;
        _house.SignalingActivated += OnChangeVolume;
    }

    private void OnDisable()
    {
        _house.ThiefEntered -= OnPlaySound;
        _house.SignalingActivated -= OnChangeVolume;
    }

    private void OnPlaySound()
    {
        _audioSource.Play();
    }

    private void OnChangeVolume()
    {
        if (_changeVolumeWorks != null)
        {
            StopCoroutine(_changeVolumeWorks);
        }

        _changeVolumeWorks = StartCoroutine(ChangeVolume(CheckThiefInHouse()));
    }

    private IEnumerator ChangeVolume(int targetVolume)
    {
        float volumeDelta;

        while (_audioSource.volume != targetVolume)
        {          
            volumeDelta = _volume * Time.deltaTime;
            
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeDelta);

            yield return null;
        }
    }

    private int CheckThiefInHouse()
    {
        int targetVolume;

        if (_house.IsContainsThief == true)
        {
            targetVolume = 1;
        }
        else
        {
            targetVolume = 0;
        }

        return targetVolume;
    }
}

