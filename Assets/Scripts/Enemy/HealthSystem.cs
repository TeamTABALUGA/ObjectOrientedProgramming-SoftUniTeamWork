using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {
    
    internal float damage;
    public float health = 10;
    public bool isAlive = true;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        HealthLogic();
        if (this.health <= 0)
        {
            this.isAlive = false;
            //Destroy(this.gameObject);
        }
	}

    public void HealthLogic()
    {
        if (damage != 0)
        {
            health -= damage;
            damage = 0;
        }
    }
}
