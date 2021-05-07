using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed = 5;

    public AudioClip enemyExplosionSound;

    public UIManager ui_Manager;

    // Start is called before the first frame update
    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);


        if (transform.position.y >= 5.6f) {
            Destroy(this.gameObject);
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy") {


            ui_Manager.increaseScore();
            Destroy(collision.gameObject);
            AudioSource.PlayClipAtPoint(enemyExplosionSound, transform.position);

            Destroy(this.gameObject);


        }

    }

}
