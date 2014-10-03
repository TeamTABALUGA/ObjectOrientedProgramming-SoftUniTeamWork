using UnityEngine;
using System.Collections;

public class PlayerDemo : MonoBehaviour
{
    
    private Vector3 position;
    private float speed = 10;
    private RaycastHit hit;
    void Start()
    {

    }

    void Update()
    {
        MoveWASD();
        Vector3 pointCoord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotate = Quaternion.LookRotation(pointCoord - transform.position);

        rotate.x = 0;
        rotate.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, 12f);


    }

    public void MoveWASD()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        transform.position += (Vector3.forward * (-horizontalMove) + Vector3.right * verticalMove) * speed * Time.deltaTime;
    }
}
