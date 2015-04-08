using UnityEngine;
using System.Collections;

public class Bulbler2 : MutantBase
{
    Animator animator;
    private bool isBiting = false;
    public FirstPlayer playerScript;
    // Use this for initialization
    void Start()
    {
        this.MovementSpeed = 2f;
        this.Damage = 10;
        this.RotationSpeed = 2;
        this.Health = 100;
        this.Score = 1230;
        this.Xp = 45;

        animator = GetComponent<Animator>();
        animator.SetBool("Attack", false);

        //this.FollowTarget();
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdatingFollow();
        //animator.SetBool("Attack", false);
    }
    void OnTriggerEnter(Collider other)
    {
        //animator = GetComponent(Animator);
        if (other.tag == "Player")
        {
            MovementSpeed = 0;
            animator.SetBool("Attack", true);
            isBiting = true;
            if (playerScript.Health > 0)
            {
                StartCoroutine(StartKilling());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //animator = GetComponent(Animator);
        if (other.tag == "Player")
        {
            MovementSpeed = 3;
            animator.SetBool("Attack", false);
            isBiting = false;
            StopCoroutine(StartKilling());
        }
    }

    void BiteThePlayer()
    {
        playerScript.Health -= Damage;
    }

    IEnumerator StartKilling()
    {
        BiteThePlayer();
        while (isBiting)
        {
            yield return new WaitForSeconds(20);
            BiteThePlayer();
        }
    }
}
