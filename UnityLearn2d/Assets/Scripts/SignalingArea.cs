using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingArea : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    public bool IsEntered { get; private set; } = false;
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEntered = !IsEntered;

        if (IsEntered == true)
            _signaling.StartAlarm();
        else
            _signaling.StopAlarm();
    }
}
