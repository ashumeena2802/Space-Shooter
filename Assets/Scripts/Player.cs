using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 5;
    private float verticalInput;
    private float horizontalInput;



    void Start()
    {
        
    }

    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);


        if (transform.position.y >= -0.6f) {
            transform.position = new Vector3(transform.position.x, -0.6f, 0);
        }


        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }

        if (transform.position.x >= 8.5f)
        {
            transform.position = new Vector3(8.5f,transform.position.y,0);
        }


        if (transform.position.x <= -8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }


       

    }
}
