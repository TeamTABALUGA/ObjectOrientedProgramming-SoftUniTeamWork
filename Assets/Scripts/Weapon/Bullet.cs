using UnityEngine;
using System.Collections;

/// <summary>
/// Create new Bullet object for specified weapon object
/// Requre: 
/// float Damage
/// float ZoneOfEffect
/// </summary>
public abstract class Bullet : MonoBehaviour
{
    private float timeDestroyBullet;
    public GameObject spatterEffect;
    private float zoneOfEffect;
    private float damage;
    private int level = 0;

    public int Level
    {
        get { return this.level = 0; }
        set { this.level = value; }
    }
    

    /// <summary>
    /// How many damage you deal in an enemy
    /// </summary>
    public float Damage
    {
        get
        {
            if (this.damage <= 0f)
            {
                throw new MissingReferenceException("Damage of that weapon can't be 0 ");
            }
            return this.damage;
        }
        set
        {
            this.damage = value;
        }
    }


    /// <summary>
    /// What is the range of the effect from weapon projectile
    /// </summary>
    public float ZoneOfEffect
    {
        get
        {
            if (this.ZoneOfEffect <= 0)
            {
                throw new MissingReferenceException("Zone Of effect can't be neutral or negative number");
            }
            return this.zoneOfEffect;
        }
        set
        {
            this.zoneOfEffect = value;
        }
    }

    /// <summary>
    /// How many time is need to destroy the bullet object in range [0...20]
    /// </summary>
    public float TimeDestroyBullet
    {
        get
        {
            if (this.timeDestroyBullet <= 0 || this.timeDestroyBullet > 20)
            {
                throw new MissingReferenceException("Time for destoing bullet value is invalid. Must be between 1 & 20");
            }
            return this.timeDestroyBullet;
        }
        set
        {
            this.timeDestroyBullet = value;
        }
    }

    /// <summary>
    /// Destroy object Projectile when seconds is runs out
    /// </summary>
    private void DestroyProjectile()
    {
        Destroy(this.gameObject, timeDestroyBullet);
    }

    /// <summary>
    /// Detect and return when object triger object with collision component
    /// </summary>
    /// <param name="other">detected coliders like Class Collider</param>
    void OnTriggerEnter(Collider other)
    {
        //All Objects hited with projectile
        Collider[] hitInfo = Physics.OverlapSphere(transform.position, zoneOfEffect);

        //If this component have variable Health
        foreach (var obj in hitInfo)
        {

            if ((obj.transform.GetComponent("MutantBase") as MutantBase) == true)
            {
                (obj.transform.GetComponent("MutantBase") as MutantBase).damageTaken += this.Damage;
                Instantiate(spatterEffect, transform.position, Quaternion.identity);

                Destroy(this.gameObject);
            }
        }
        Destroy(this.gameObject);
        if ((GameObject.FindGameObjectWithTag("Player").GetComponent("FirstPlayer") as FirstPlayer).Level != this.Level)
        {
            this.Level = (GameObject.FindGameObjectWithTag("Player").GetComponent("FirstPlayer") as FirstPlayer).Level;
            this.Damage += 0.823f;
            this.zoneOfEffect += 0.2f;
        }
        Debug.Log(string.Format("Bullet: lvl:{0} DMG:{1}",this.Level, this.Damage));
    }

    public override string ToString()
    {
        return string.Format("Bullet: DMG= {0}",this.Damage);
    }
}
