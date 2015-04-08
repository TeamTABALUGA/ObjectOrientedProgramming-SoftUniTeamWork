using UnityEngine;
using System.Collections;

public class Bulbler : MutantBase
{
    //Animator animator;

    // Use this for initialization
    void Start()
    {
        this.MovementSpeed = 2f;
        this.Damage = 10;
        this.RotationSpeed = 2;
        this.Health = 100;
        this.Score = 1230;
        this.Xp = 45;

        //animator = GetComponent<Animator>();
        //animator.SetBool("Attack", false);

        this.FollowTarget();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdatingFollow();
        //animator.SetBool("Attack", false);
    }

    void OnTriggerEnter(Collider other)
    {
        
        this.CollisionEnter(other);
        //animator.SetBool("Attack", true);
    }

    void OnTriggerExit(Collider other)
    {
        
        this.CollisionExit(other);
        //animator.SetBool("Attack", false);
    }
}
