using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordStand : BaseInteraction
{
    public GameObject Sword;

    public BaseWeapon TargetWeapon;

    public UnityEvent<BaseWeapon> OnPickedUp;

    public override void Interact()
    {
        if (!Sword.activeSelf)
        {
            return;
        }

        Sword.SetActive(false);
        OnPickedUp.Invoke(TargetWeapon);
    }
}
