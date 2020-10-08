using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : Gun
{
    protected override void Shoot()
    {
        base.Shoot();

        if(Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            GameObject bullet = pooler.SpawnObject("AK-47 Bullet", firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = GetDirectionToMouse().normalized * bulletSpeed;
            currentAmmo--;
        }
    }

    public void LateUpdate()
    {
        Shoot();
    }
}
