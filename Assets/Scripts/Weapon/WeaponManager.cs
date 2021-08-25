using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponManager : MonoBehaviour
{
    public List<BaseWeapon> Weapons;

    public BaseWeapon Current { get; private set; }

    private void Start()
    {
        Select<FistWeapon>();
    }

    public void Select<T>() where T : BaseWeapon
    {
        TryDeselect();
        TryUpdateSelection(Weapons.FirstOrDefault(w => w is T));
    }

    public void Select(BaseWeapon weapon)
    {
        TryDeselect();
        TryUpdateSelection(Weapons.FirstOrDefault(w => w == weapon));
    }

    public void Attack()
    {
        Current?.Attack();
    }

    public void SetWeaponSortingOrder(int order)
    {
        Current?.SetSortingOrder(order);
    }

    private void TryDeselect()
    {
        if (Current != null)
        {
            Current.Deselect();
        }
    }

    private void TryUpdateSelection(BaseWeapon newWeapon)
    {
        if (newWeapon != null)
        {
            Current = newWeapon;
            Current.Select();
        }
    }
}
