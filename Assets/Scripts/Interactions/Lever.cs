using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lever : BaseInteraction
{
    public GameObject On;
    public GameObject Off;

    public UnityEvent<bool> OnToggled;

    private bool _isOn;

    public override void Interact()
    {
        _isOn = !_isOn;

        On.SetActive(_isOn);
        Off.SetActive(!_isOn);

        OnToggled.Invoke(_isOn);
    }
}
