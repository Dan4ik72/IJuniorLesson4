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
    
    private Coroutine _changingVolumeCoroutine;

    private WaitForSeconds _changingVolumeDelay = new WaitForSeconds(0.2f);

    public void StartAlarm()
    {
        _audioSource.Play();

        _changingVolumeCoroutine = StartCoroutine(IncreaseVolume());
    }

    public void StopAlarm()
    {
        _changingVolumeCoroutine = StartCoroutine(DecreaseVolumeAndStop());
    }

    private void Start()
    {
        _audioSource.volume = 0;        
    }
    
    private IEnumerator IncreaseVolume()
    {
        TryToStopCurrentCoroutine();
        
        for (float i = _minVolume; i < _maxVolume; i += _volumeChangingStep)
        {
            _audioSource.volume += _volumeChangingStep;

            yield return _changingVolumeDelay;
        }
    }

    private IEnumerator DecreaseVolumeAndStop()
    {
        TryToStopCurrentCoroutine();

        for (float i = _audioSource.volume; i > _minVolume; i -= _volumeChangingStep)
        {
            _audioSource.volume -= _volumeChangingStep;

            yield return _changingVolumeDelay;
        }

        _audioSource.Stop();
    }

    private void TryToStopCurrentCoroutine()
    {
        if (_changingVolumeCoroutine != null)
            StopCoroutine(_changingVolumeCoroutine);
    }
}
