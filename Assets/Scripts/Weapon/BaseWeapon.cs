using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public int Damage = 10;

    private Destructible _target;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        _target = collider2D.GetComponent<Destructible>();
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        _target = null;
    }

    public void Attack()
    {
        OnAttack();
    }

    public void TryApplyDamageToTarget()
    {
        _target?.Damage(Damage);
    }

    public void Select()
    {
        gameObject.SetActive(true);
        OnSelected();
    }

    public void Deselect()
    {
        gameObject.SetActive(false);
    }


    protected virtual void OnSelected() { }

    protected abstract void OnAttack();

    public abstract void SetSortingOrder(int order);
}
