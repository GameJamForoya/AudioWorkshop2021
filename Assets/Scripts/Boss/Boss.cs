using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Collider2D Collider;
    public Animator Animator;

    public void Kill()
    {
        Collider.enabled = false;
        Animator.SetTrigger("kill");
    }
}
