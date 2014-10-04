using UnityEngine;
using System.Collections;

public class PlayerDemo : MonoBehaviour
{

    private Vector3 position;
    private float speed = 10;
    private RaycastHit hit;
    Vector3 lookTarget;
    void Start()
    {

    }

    void Update()
    {
        MoveWASD();
        Rotation();
    }

    private void Rotation()
    {
         var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
         RaycastHit hit;
    if (Physics.Raycast (ray, out hit)) {
        lookTarget = hit.point;
    }
 
    transform.LookAt(lookTarget);
    }

    public void MoveWASD()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        transform.position += (Vector3.forward * (-horizontalMove) + Vector3.right * verticalMove) * speed * Time.deltaTime;
    }
}
