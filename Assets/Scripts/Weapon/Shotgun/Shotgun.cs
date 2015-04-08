using UnityEngine;
using System.Collections;

public class Shotgun : Weapon
{

    void Start()
    {
        this.DelayWeaponSeconds = 1.5f;
        this.Force = 2000f;
        this.numberOfBullets = 20;
        this.RandomMinMax = new float[2] { -0.06f, 0.07f };
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Shoot();
        }
    }
}
