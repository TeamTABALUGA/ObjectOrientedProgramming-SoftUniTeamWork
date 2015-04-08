using UnityEngine;
using System.Collections;

public class Zombie : MutantBase
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        this.MovementSpeed = 2;
        this.Damage = 3;
        this.RotationSpeed = 3;
        this.Health = 10;
        this.Score = 956;
        this.Xp = 32;

        animator = GetComponent<Animator>();
        animator.SetBool("Atack", false);

        this.FollowTarget();
    }

    void Update()
    {
        this.UpdatingFollow();
        animator.SetBool("Atack", false);
        
    }

    void OnTriggerEnter(Collider other) 
    {
        this.CollisionEnter(other);
        //animator.SetBool("Atack", true);
    }

    void OnTriggerExit(Collider other)
    {
        this.CollisionExit(other);
        animator.SetBool("Atack", false);
    }
}
