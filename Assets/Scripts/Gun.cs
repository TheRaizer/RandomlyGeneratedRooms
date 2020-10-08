using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Gun : Weapon
{
    protected ObjectPooler pooler;
    [SerializeField] private Sprite[] gunSprites;//0 = down, 1 = diag down right, 2 = right, 3 = diag up right, 4 = up, 5 = diag up left, 6 = left, 7 = diag down left

    [SerializeField] private int maxAmmo = 0;
    [SerializeField] protected int currentAmmo = 0;

    [SerializeField] private float reloadTime = 0;
    [SerializeField] protected float bulletSpeed = 0;

    [SerializeField] private GameObject[] firingPoints;

    protected Transform firePoint;
    private WaitForSeconds reloadYield;
    private Camera mainCamera;
    private SpriteRenderer _renderer;


    private void Awake()
    {
        currentAmmo = maxAmmo;
        reloadYield = new WaitForSeconds(reloadTime);
        pooler = FindObjectOfType<ObjectPooler>();

        mainCamera = Camera.main != null ? Camera.main : throw new ArgumentNullException();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeGunSprite();          //DO THIS OR CHANGE IT WHENEVER THE PLAYER SHOOTS
    }

    private void ChangeGunSprite()
    {
        Vector2 dirToMouse = GetDirectionToMouse();

        float angle = Mathf.Atan2(dirToMouse.y, dirToMouse.x) * Mathf.Rad2Deg;
        if(angle > -112 && angle < -67)
        {
            _renderer.sprite = gunSprites[0];
            EnableFiringPoint(0);
        }
        else if(angle > -67 && angle < -22)
        {
            _renderer.sprite = gunSprites[1];
            EnableFiringPoint(1);
        }
        else if(angle > -22 && angle < 23)
        {
            _renderer.sprite = gunSprites[2];
            EnableFiringPoint(2);
        }
        else if(angle > 23 && angle < 68)
        {
            _renderer.sprite = gunSprites[3];
            EnableFiringPoint(3);
        }
        else if (angle > 68 && angle < 113)
        {
            _renderer.sprite = gunSprites[4];
            EnableFiringPoint(4);
        }
        else if (angle > 113 && angle < 158)
        {
            _renderer.sprite = gunSprites[5];
            EnableFiringPoint(5);
        }
        else if (angle > 158 && angle < 203)
        {
            _renderer.sprite = gunSprites[6];
            EnableFiringPoint(6);
        }
        else if (angle > -157 && angle < -112)
        {
            _renderer.sprite = gunSprites[7];
            EnableFiringPoint(7);
        }
    }

    protected virtual void Shoot() { }

    protected virtual IEnumerator Reload()
    {
        yield return reloadYield;
        currentAmmo = maxAmmo;
    }

    protected virtual Vector2 GetDirectionToMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private Vector2 GetDirectionFromMouse()//used for recoil which hasnt been implemented at
    {
        return transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void ChangeReloadTime(float time)
    {
        reloadTime = time;
        reloadYield = new WaitForSeconds(reloadTime);
    }

    private void EnableFiringPoint(int x)
    {
        firePoint = firingPoints[x].transform;
        firingPoints[x].SetActive(true);

        for(int i = 0; i < firingPoints.Length; i++)
        {
            if (i == x)
                continue;
            firingPoints[i].SetActive(false);
        }
    }
}
