using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SignalingArea _signalingArea;

    private float _minVolume = 0;
    private float _maxVolume = 1;
    private float _volumeChangingStep = 0.03f;
    private float _secondsToWaitInCoroutine = 0.2f;

    private Coroutine _changingVolumeCoroutine;

    private void Start()
    {
        _audioSource.volume = 0;        
    }
    
    private IEnumerator IncreaseVolume()
    {
        if (_changingVolumeCoroutine != null)
            StopCoroutine(_changingVolumeCoroutine);

        var waitForSeconds = new WaitForSeconds(_secondsToWaitInCoroutine);

        for (float i = _minVolume; i < _maxVolume; i += _volumeChangingStep)
        {
            _audioSource.volume += _volumeChangingStep;

            yield return waitForSeconds;
        }
    }

    private IEnumerator DecreaseVolumeAndStop()
    {
        if (_changingVolumeCoroutine != null)
            StopCoroutine(_changingVolumeCoroutine);

        var waitForSeconds = new WaitForSeconds(_secondsToWaitInCoroutine);

        for (float i = _audioSource.volume; i > _minVolume; i -= _volumeChangingStep)
        {
            _audioSource.volume -= _volumeChangingStep;

            yield return waitForSeconds;
        }

        _audioSource.Stop();
    }

    public void StartAlarm()
    {
        _audioSource.Play();

        _changingVolumeCoroutine = StartCoroutine(IncreaseVolume());
    }

    public void StopAlarm()
    {
        _changingVolumeCoroutine = StartCoroutine(DecreaseVolumeAndStop());
    }
}
