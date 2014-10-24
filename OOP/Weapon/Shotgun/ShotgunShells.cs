using UnityEngine;
using System.Collections;

public class ShotgunShells : Bullet {

	// Use this for initialization
	void Start () 
    {
        this.Damage = 5;
        this.ZoneOfEffect = 2f;
        this.TimeDestroyBullet = 2;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
