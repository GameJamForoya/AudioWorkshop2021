using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Animator Animator;
    public AudioSource GateSound;
    public void SetOpenStatus(bool status)
    {
        GateSound.Play();
        Animator.SetBool("open", status);
    }

    public void OnAnimationEnd()
    {
        GateSound.Stop();
    }
}
