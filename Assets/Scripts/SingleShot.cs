using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingleShot : RangeWeapon
{
    [SerializeField] private Transform lance;
    public override void Use()
    {
        Debug.Log("using Gun" + ItemInfo.ItemName);
        Shoot(itemGameObject);
    }

    public void Shoot( GameObject weapon)
    {
        var position = weapon.transform.position;
        Debug.Log(position.normalized);
        Transform projectileTransform = Instantiate(lance, position, Quaternion.identity);
        
        Vector3 Shootdir = position;
        projectileTransform.GetComponent<Projectile>().Setup(Shootdir);
    }
}
