using UnityEngine;
using System.Collections;

public class Handgun : Weapon {

	void Start () {
        this.Force = 2500f;
        this.DelayWeaponSeconds = 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
	}
}
