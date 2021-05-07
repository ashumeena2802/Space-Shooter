using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5;

    public GameObject spawnManager; 

    void Awake()
    {
        
    }

    void Update()
    {

        Movement();
        

    }

    void Movement() {


        transform.Translate(Vector3.down * speed * Time.deltaTime);


        if (transform.position.y <= -5.8f)
        {
            float randomX = Random.Range(-8.3f, 8.3f);

            transform.position = new Vector3(randomX, 5.8f, transform.position.z);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            // Get player component
            Player _player = collision.GetComponent<Player>();

            // Calling player damage recieve script
            _player.RecieveDamage();
            

            Destroy(this.gameObject);



        }
    }


}




