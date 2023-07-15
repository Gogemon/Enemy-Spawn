using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [SerializeField] private float _maxDelta;

    private Coroutine _changeVolumeCoroutine;
    private AudioSource _audioSource;

    private float _minVolume = 0;
    private float _maxVolume = 1;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void StartVolumeChanger(bool isExit)
    {
        float volumeValue = isExit ? _minVolume : _maxVolume;

        if (_changeVolumeCoroutine != null)
        {
            StopChangeVolumeCoroutine();
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume(volumeValue));
    }

    private IEnumerator ChangeVolume(float volumeValue)
    {
        bool isWorking = true;

        while (isWorking)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeValue, _maxDelta * Time.deltaTime);

            if (_audioSource.volume == volumeValue)
            {
                StopChangeVolumeCoroutine();
            }

            yield return null;
        }
    }
    
    private void StopChangeVolumeCoroutine()
    {
        StopCoroutine(_changeVolumeCoroutine);
    }
}
