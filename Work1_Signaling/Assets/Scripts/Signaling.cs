using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private House _house;

    private Coroutine ChangeVolumeWorks;
    private float _volume = 1;

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
        if (ChangeVolumeWorks != null)
        {
            StopCoroutine(ChangeVolumeWorks);
        }

        ChangeVolumeWorks = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        float volumeDelta;
        int targetVolume;
        
        if (_house.IsContainsAlien == true)
        {
            targetVolume = 1;
        }
        else
        {
            targetVolume = 0;
        }

        while (_audioSource.volume != targetVolume)
        {          
            volumeDelta = _volume * Time.deltaTime;
            
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeDelta);

            yield return null;
        }
    }
}

