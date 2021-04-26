using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingleShot : RangeWeapon
{
    [SerializeField] private GameObject lance;
    [SerializeField] private float speed;

    public override void Use()
    {
        Debug.Log("using Gun" + ItemInfo.ItemName);
        Shoot(itemGameObject);
    }

    public void Shoot(GameObject weapon)
    {
        
        GameObject instBullet = Instantiate(lance, weapon.transform.position, weapon.transform.rotation);
        Transform instBulletRigidbody = instBullet.GetComponent<Transform>();
        instBulletRigidbody.GetComponent<Rigidbody>().AddForce(weapon.transform.up * speed);
    }

    
}
