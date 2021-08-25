using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : BaseWeapon
{
    public AudioSource PickedUpSound;

    public Animator Animator;
    public SpriteRenderer Renderer;

    public override void SetSortingOrder(int order)
    {
        Renderer.sortingOrder = order;
    }

    protected override void OnAttack()
    {
        Animator.SetTrigger("attack");
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForEndOfFrame();
        Animator.ResetTrigger("attack");
    }

    protected override void OnSelected()
    {
        PickedUpSound.Play();
        Animator.SetTrigger("optain");
    }
}
