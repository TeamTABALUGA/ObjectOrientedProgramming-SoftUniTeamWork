using UnityEngine;
using System.Collections;

public class MashineGunBullet : Bullet {

	// Use this for initialization
	void Start () {
        this.Damage = 3.5f;
        this.ZoneOfEffect = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
