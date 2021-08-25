using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public int MaxHealth = 1;

    public UnityEvent OnDestruction;

    private int _health;

    private void Start()
    {
        _health = MaxHealth;
    }

    public void Damage(int amount)
    {
        _health = Mathf.Max(_health - amount, 0);
        if (_health == 0)
        {
            OnDestruction.Invoke();
        }
    }
}
