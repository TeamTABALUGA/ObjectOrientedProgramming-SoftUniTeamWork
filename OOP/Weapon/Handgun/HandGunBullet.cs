using UnityEngine;
using System.Collections;

public class HandGunBullet : Bullet {

	// Use this for initialization
	void Start () {
        this.Damage = 5;
        this.ZoneOfEffect = 3.5f;
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
