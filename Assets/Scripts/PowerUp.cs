using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed = 2;


    // power up Id
    public float powerUpId;


    void Start()
    {
        


    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= -6) {
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            Player player = collision.GetComponent<Player>();

            //Triple Shot
            if (powerUpId == 0) {

                player.PlayerTriplesShotUp();

            }
            //Speed
            if (powerUpId == 1) {

                player.PlayerSpeedBooster();


            }
            //Shield
            if (powerUpId == 2) {

                player.PlayerShieldUp();

            }
            Destroy(this.gameObject);
        
        }


    }


}
