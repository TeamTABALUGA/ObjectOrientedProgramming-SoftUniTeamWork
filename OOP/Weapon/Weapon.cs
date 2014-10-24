using UnityEngine;
using System.Collections;

/// <summary>
/// Initilize ne weapon with requared parameters 
/// float Force 
/// float DelayWeapon 
/// AudioClip shot ->initilize in Unity
/// target projectile.Prefab Object ProjectileMaterial -> initilize in Unity
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    private bool isReadyToShoot = true;
    public GameObject projectileMaterial;
    private GameObject projectileWithForce;
    private float force;
    private float delayWeaponSeconds;
    public AudioClip shot;
    public float numberOfBullets = 1;
    private float timeDestroyBullet = 1;
    public float[] RandomMinMax = new float[2] { 0f, 0f };

    public float NumberOfBullets
    {
        get
        {
            if (this.numberOfBullets <= 0)
            {
                throw new MissingReferenceException("Number of bullets can't be 0 or less");
            }
            return this.numberOfBullets;
        }
        set
        {
            this.numberOfBullets = value;
        }
    }
    /// <summary>
    /// Projectile force of pushing from barrel
    /// </summary>
    public float Force
    {
        get
        {
            if (this.force < 100f && this.force > 10000f)
            {
                throw new UnassignedReferenceException("Projectile force is invalid. Must be in range [100f...10000f]");
            }
            return this.force;
        }
        set
        {
            if (this.force < 100f && this.force > 10000f)
            {
                throw new UnassignedReferenceException("Projectile force is invalid. Must be in range [100...10000]");
            }
            this.force = value;
        }
    }

    /// <summary>
    /// Property check how many time will delay weapon before another shoot
    /// </summary>
    public float DelayWeaponSeconds
    {
        get
        {
            if (this.delayWeaponSeconds < 0 || this.delayWeaponSeconds > 300)
            {
                throw new UnassignedReferenceException("Projectile force is invalid. Must be in range [100...10000]");
            }
            return this.delayWeaponSeconds;
        }
        set
        {
            this.delayWeaponSeconds = value;
        }
    }

    /// <summary>
    /// Shoot 1 projectile with specified force
    /// </summary>
    public virtual void Shoot()
    {
        if (this.isReadyToShoot == true)
        {
            StartCoroutine(ShootWithDelay(this.RandomMinMax[0], this.RandomMinMax[1]));
            this.audio.PlayOneShot(shot, 0.5f);
        }
    }

    //Initilize, shoot and delay next shoot 
    private IEnumerator ShootWithDelay(float rndMin, float rndMax)
    {
        this.isReadyToShoot = false;

        for (int i = 0; i < numberOfBullets; i++)
        {
            projectileWithForce = Instantiate(this.projectileMaterial, this.transform.position, new Quaternion(this.transform.rotation.x,
                this.transform.rotation.y + Random.Range(rndMin, rndMax),
                this.transform.rotation.z + Random.Range(rndMin, rndMax),
                this.transform.rotation.w)) as GameObject;

            this.projectileWithForce.rigidbody.AddRelativeForce(new Vector3(0, 0, this.Force));

            Destroy(projectileWithForce.gameObject, timeDestroyBullet);

        }

        yield return new WaitForSeconds(this.DelayWeaponSeconds);
        this.isReadyToShoot = true;
    }

}
