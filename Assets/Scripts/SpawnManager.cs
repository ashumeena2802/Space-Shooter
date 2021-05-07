using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameManager gameManager;

    public GameObject[] PowerUp;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawningEnemyPrefab());
        StartCoroutine(SpawningPowerUps());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawningEnemyPrefab()
    {
        while (gameManager.gameOver == false)
        {

            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.3f, 8.6f), 5.8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }

    }

    IEnumerator SpawningPowerUps() {
        while (gameManager.gameOver == false) {

            Instantiate(PowerUp[Random.Range(0, 3)], new Vector3(Random.Range(-8.3f, 8.6f), 5.8f, 0), Quaternion.identity);
            yield return new WaitForSeconds(8);
        
        
        
        }

    
    
    }

}
