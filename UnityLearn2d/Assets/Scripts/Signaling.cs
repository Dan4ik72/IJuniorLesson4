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

    private Coroutine _increaseVolumeCoroutine;
    private Coroutine _decreaseVolumeCoroutine;

    private void Start()
    {
        _audioSource.volume = 0;        
    }
    
    private IEnumerator IncreaseVolume()
    {
        if(_decreaseVolumeCoroutine != null)
             StopCoroutine(_decreaseVolumeCoroutine);

        for (float i = _minVolume; i < _maxVolume; i += _volumeChangingStep)
        {
            _audioSource.volume += _volumeChangingStep;

            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator DecreaseVolumeAndStop()
    {   
        if(_increaseVolumeCoroutine != null)
               StopCoroutine(_increaseVolumeCoroutine);

        for (float i = _audioSource.volume; i > _minVolume; i -= _volumeChangingStep)
        {
            _audioSource.volume -= _volumeChangingStep;

            yield return new WaitForSeconds(0.2f);
        }

        _audioSource.Stop();
    }

    public void StartAlarm()
    {
        _audioSource.Play();

        _increaseVolumeCoroutine = StartCoroutine(IncreaseVolume());
    }

    public void StopAlarm()
    {
        _decreaseVolumeCoroutine = StartCoroutine(DecreaseVolumeAndStop());
    }
}
