using UnityEngine;
using System.Collections;

/// <summary>
/// Create new Mutant based creature
/// Requared: float MovementSpeed, float Damage, float Rotation Speed, float Health, float Score, float Xp, Player target -> from Unity.
/// </summary>
public abstract class MutantBase : MonoBehaviour, IMutant, ICreature
{
    private const float stop = 0;
    private float movementSpeed;
    private float switchSpeed;

    private bool isBiting = false;
    private float thisDamage;
    internal float damageTaken;
    private float rotationSpeed;
    private float health;
    private float score;
    private float xp;
    private float byteDelay;
    private bool isAlive = true;
    public AudioClip death;

    internal Transform target;
    internal Transform thisTransform;

    private FirstPlayer playerTargetScript;

    /// <summary>
    /// Check wheather is this object is alive with bolean value
    /// </summary>
    public bool IsAlive
    {
        get
        {
            return this.isAlive;
        }
        private set
        {
            this.isAlive = value;
        }
    }

    /// <summary>
    /// How many time delay next damage to the target on float
    /// </summary>
    public float ByteDelay
    {
        get
        {
            if (this.byteDelay < 0 || this.byteDelay > 10)
            {
                throw new MissingReferenceException("The Delay is in seconds and must be in range [0...10]");
            }
            return this.byteDelay;
        }
        set
        {
            if (this.byteDelay < 0 || this.byteDelay > 10)
            {
                throw new MissingReferenceException("The Delay is in seconds and must be in range [0...10]");
            }
            this.byteDelay = value;
        }
    }

    /// <summary>
    /// How many damage in float will reseave target
    /// </summary>
    public float Damage
    {
        get
        {
            if (this.thisDamage <= 0f)
            {
                throw new MissingReferenceException("Damage must be positive number.");
            }
            return this.thisDamage;
        }
        set
        {
            if (value <= 0f)
            {
                throw new MissingReferenceException("Damage must be positive number.");
            }
            this.thisDamage = value;
        }
    }

    /// <summary>
    /// What time spend to rotate 
    /// </summary>
    public float RotationSpeed
    {
        get
        {
            return this.rotationSpeed;
        }
        set
        {
            if (value <= 0f)
            {
                throw new MissingReferenceException("Rotation speed must be positive number.");
            }
            this.rotationSpeed = value;
        }
    }

    /// <summary>
    /// Float representation of health
    /// </summary>
    public float Health
    {
        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }
    }

    /// <summary>
    /// What is the speed of movement
    /// </summary>
    public float MovementSpeed
    {
        get
        {
            return this.movementSpeed;
        }
        set
        {
            if (this.movementSpeed <= 0f && this.movementSpeed >= 200)
            {
                throw new MissingReferenceException("Movement Speed must be positive number and must be less than 200");
            }
            this.movementSpeed = value;
        }
    }

    /// <summary>
    /// Amount of score given on death
    /// </summary>
    public float Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
        }
    }

    /// <summary>
    /// Amount of expirience whitch given on death
    /// </summary>
    public float Xp
    {
        get
        {
            return this.xp;
        }
        set
        {
            this.xp = value;
        }
    }


    private void BiteThePlayer()
    {
        playerTargetScript.Health -= this.Damage;
    }

    private IEnumerator StartKilling()
    {
        BiteThePlayer();
        while (isBiting)
        {
            yield return new WaitForSeconds(1);
            BiteThePlayer();
        }
    }

    public void Awake()
    {
        thisTransform = transform;
    }

    public virtual void FollowTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        playerTargetScript = GameObject.FindGameObjectWithTag("Player").GetComponent("FirstPlayer") as FirstPlayer;
        this.switchSpeed = this.MovementSpeed;
    }

    public void UpdatingFollow()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        thisTransform.Translate(Vector3.forward * this.switchSpeed * Time.deltaTime);

        HealthLogic();

    }

    // Destroy this enemy and gain XP Score Health of player
    private void Destroy()
    {

        playerTargetScript.Xp += this.Xp;
        playerTargetScript.Score += this.Score;
        if (playerTargetScript.Health + 0.05 >= 100)
        {
            playerTargetScript.Health = 100;
        }
        playerTargetScript.Health += 0.05f;
        Destroy(this.gameObject);
        Debug.Log(playerTargetScript);
    }

    //On void TrigerEnter 
    public void CollisionEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.switchSpeed = stop;
            this.isBiting = true;
            if (this.playerTargetScript.Health > 0)
            {
                StartCoroutine(StartKilling());
            }
        }

        //if ((other.tag == "Player"))
        //{
        //    this.switchSpeed = stop;
        //}
    }


    public virtual void CollisionExit(Collider other)
    {
        if ((other.tag == "Player"))
        {
            this.switchSpeed = this.movementSpeed;
            this.isBiting = false;
            StopCoroutine(StartKilling());
            this.switchSpeed = this.MovementSpeed;
        }
    }

    public void HealthLogic()
    {
        if (this.damageTaken != 0)
        {
            this.Health -= this.damageTaken;
            this.damageTaken = 0;
        }

        if (this.Health <= 0)
        {
            this.IsAlive = false;
            this.Destroy();
        }
    }
}
