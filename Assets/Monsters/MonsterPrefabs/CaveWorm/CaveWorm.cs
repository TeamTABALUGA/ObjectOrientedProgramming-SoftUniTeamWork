using UnityEngine;
using System.Collections;

public class CaveWorm : MutantBase
{

    public AnimationClip Walk;
    public AnimationClip Attack;
    public AnimationClip Die;

    // Use this for initialization
    void Start()
    {
        this.MovementSpeed = 2.78f;
        this.Damage = 60;
        this.RotationSpeed = 1;
        this.Health = 6000;
        this.Score = 11230;
        this.Xp = 450;

        animation.CrossFade(Walk.name);
        this.FollowTarget();

    }

    // Update is called once per frame
    void Update()
    {
        this.UpdatingFollow();
    }

    void OnTriggerEnter(Collider other)
    {
        this.CollisionEnter(other);
        animation.CrossFade(Attack.name);
    }

    void OnTriggerExit(Collider other)
    {
        this.CollisionExit(other);
        animation.CrossFade(Walk.name);
    }
}
