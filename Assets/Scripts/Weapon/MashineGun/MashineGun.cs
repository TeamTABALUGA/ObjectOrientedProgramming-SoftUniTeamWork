using UnityEngine;
using System.Collections;

public class MashineGun : Weapon {

	// Use this for initialization
	void Start () 
    {
        this.Force = 2500f;
        this.DelayWeaponSeconds = 0.1f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
            this.Shoot();
        }
	}
}
