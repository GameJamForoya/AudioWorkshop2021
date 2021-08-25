using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistWeapon : BaseWeapon
{
    public Animator Animator;
    public SpriteRenderer Renderer;

    public override void SetSortingOrder(int order)
    {
        Renderer.sortingOrder = order;
    }

    protected override void OnAttack()
    {
        Animator.SetTrigger("attack");
    }
}
