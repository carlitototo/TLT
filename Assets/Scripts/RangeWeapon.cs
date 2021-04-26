using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : Item
{
    [SerializeField] public GameObject user;
    public abstract override void Use();
}
