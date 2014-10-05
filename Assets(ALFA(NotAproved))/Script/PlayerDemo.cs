using UnityEngine;
using System.Collections;

public class PlayerDemo : MonoBehaviour
{

    private Vector3 position;
    private float speed = 10;
    private RaycastHit hit;
    Vector3 lookTarget;

    public AnimationClip idle;
    public AnimationClip run;
    public AnimationClip fire;
    public AnimationClip die;

    //TODO:Health system
    private float health = 65000;

    void Start()
    {

    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        //Moving & Firing
        if (horizontalMove != 0 || verticalMove != 0)
        {
            MoveWASD(horizontalMove, verticalMove);
            Rotation();
        }
        // Idle
        else
        {
            // Fire
            if (Input.GetMouseButton(0))
            {
                //TODO: Mouse Button Shoot the enemy
                animation.CrossFade(fire.name);
            }
            else
            {
                animation.CrossFade(idle.name);
            }

            Rotation();

        }
        //Dead
        if (health <= 0)
        {
            animation.CrossFade(die.name);
        }

    }

    private void Rotation()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;

        }
        transform.LookAt(lookTarget);
    }

    public void MoveWASD(float horizontalMove, float verticalMove)
    {
        transform.position += (Vector3.forward * (-horizontalMove) + Vector3.right * verticalMove) * Time.deltaTime * speed;

        animation.CrossFade(run.name);
    }

}
