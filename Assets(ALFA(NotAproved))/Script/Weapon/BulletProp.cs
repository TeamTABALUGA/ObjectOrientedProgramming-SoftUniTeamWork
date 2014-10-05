using UnityEngine;
using System.Collections;

public class BulletProp : MonoBehaviour {
    float timeDestroyBullet = 2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(this.gameObject, timeDestroyBullet);

	}
}
