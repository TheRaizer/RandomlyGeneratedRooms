using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

    [SerializeField] private float speed;

    private float horiz;
    private float vert;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        weapons.Add("Primary", null);
        weapons.Add("Secondary", null);
    }

    private void FixedUpdate()
    {
        horiz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(horiz, vert);

        rb.velocity = dir.normalized * speed;
        
    }

    public void AssignWeapon(bool isPrimary, Weapon weapon)
    {
        if(isPrimary)
        {
            weapons["Primary"] = weapon;
        }
        else
        {
            weapons["Secondary"] = weapon;
        }
    }
}
