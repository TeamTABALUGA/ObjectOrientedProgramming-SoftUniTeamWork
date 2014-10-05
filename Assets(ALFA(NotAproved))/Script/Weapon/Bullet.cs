using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    
    public GameObject projectile;
    private GameObject projectileWithForce;
    private float force = 1000000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
                projectileWithForce = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

                projectileWithForce.rigidbody.AddRelativeForce(new Vector3(0, 0, force));
        }
	}
}
