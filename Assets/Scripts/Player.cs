using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public UIManager ui_Manager;

    public float speed = 5;
    private float verticalInput;
    private float horizontalInput;

    public float health = 100;

    public GameObject laserPrefab;
    public GameObject tripleLaserPrefab;
    public Transform laserLaunchPos;

    // If able to fire
    public float canFire;
    public float fireRate = 0.2f;

    public bool canSpeedUp = false;
    public bool canShieldUp = false;
    public bool canShootTripleLasers = false;

    public AudioClip laserShootSound;

    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    void Update()
    {

        Movement();

        Shooting();
        


    }


    public void RecieveDamage() {

        // For decreasing Player's health
        if (canShieldUp == false)
        {
            health -= 30;
            ui_Manager.lives -= 1;

        }


        if (health <= 0) {

            // If player heath < 0, Destroy it.
            Destroy(this.gameObject);
        
        }
    
    }

    void Shooting() {


        canFire = canFire + Time.deltaTime;


        if (canFire >= fireRate)
        {

            if (Input.GetKey(KeyCode.Space))
            {

                if (canShootTripleLasers)
                {
                    Instantiate(tripleLaserPrefab, transform.position, Quaternion.identity);
                    canFire = 0;
                    AudioSource.PlayClipAtPoint(laserShootSound, transform.position);
                }
                else
                {

                    Instantiate(laserPrefab, laserLaunchPos.position, Quaternion.identity);
                    canFire = 0;
                    AudioSource.PlayClipAtPoint(laserShootSound, transform.position);

                }

            }
        }

    }

    void Movement() {


        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        if (canSpeedUp == true)
        {

            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * 8 * Time.deltaTime);

        }
        else {

            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);

        }



        // Limiting our y-axis bottom pos
        if (transform.position.y >= -0.6f)
        {
            transform.position = new Vector3(transform.position.x, -0.6f, 0);
        }


        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }

        if (transform.position.x >= 8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, 0);
        }


        if (transform.position.x <= -8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, 0);
        }
    }

    public void PlayerSpeedBooster() {

        canSpeedUp = true;

        StartCoroutine(SpeedDownRoutine());
    }

    IEnumerator SpeedDownRoutine() {

        yield return new WaitForSeconds(7);
        canSpeedUp = false;
    
    }
    
    
    public void PlayerShieldUp() {

        canShieldUp = true;

        StartCoroutine(ShieldDownRoutine());
    }

    IEnumerator ShieldDownRoutine() {

        yield return new WaitForSeconds(7);
        canShieldUp = false;
    
    }
    
    public void PlayerTriplesShotUp() {

        canShootTripleLasers = true;

        StartCoroutine(TripleShotDownRoutine());
    }

    IEnumerator TripleShotDownRoutine() {

        yield return new WaitForSeconds(7);
        canShootTripleLasers = false;
    
    }

}
