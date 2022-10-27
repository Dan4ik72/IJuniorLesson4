using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingArea : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _isEntered  = false;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isEntered = !_isEntered;

        if (_isEntered == true)
            _signaling.StartAlarm();
        else
            _signaling.StopAlarm();
    }
}
