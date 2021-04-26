using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed;
    private Vector3 ShootDir;
    public void Setup(Vector3 ShootDir)
    {
        this.ShootDir = ShootDir;
    }

    private void Update()
    {
        transform.position = ShootDir * 100f * Time.deltaTime; 
    }
}
