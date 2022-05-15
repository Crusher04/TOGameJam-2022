using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int waveCounter = 1;
    private int enemyCounter = 0;                       //Enemy spawned so far per wave
    private int maxWaves = 3;
    private Timer WaveTimer;
    private int[] enemySpawnLimit = new int[3];         //Array to hold Max Enemies spawning per wave

    public GameObject cloudOne;
    public GameObject cloudTwo;
    public GameObject cloudThree;
    public GameObject enemyGround;
    public GameObject enemyRanged;
    public GameObject enemyBoss;

    public bool cloudsSpawned = false;
    private bool EnemySpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        //Set enemy 
        enemySpawnLimit[0] = 10;
        enemySpawnLimit[1] = 15;
        enemySpawnLimit[2] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!cloudsSpawned)
        {
            cloudsSpawned = true;
            float randomCloudTimer = Random.Range(3.0f, 5.0f);
            Debug.Log("Cloud Spawned! Timer = " + randomCloudTimer);
            StartCoroutine(ExecuteAfterTime(randomCloudTimer));
        }

        if (waveCounter == 1 && WaveTimer.timeValue > 0)
        {
            float timeBetweenEnemySpawns = Random.Range(5, 15);         //5-15 Seconds between spawns

            if (enemyCounter <= enemySpawnLimit[waveCounter - 1])
            { 
                StartCoroutine(ExecuteAfterTime(timeBetweenEnemySpawns));
                EnemySpawned = true;
            }
        }
        else
            waveCounter++;
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        //Spawning Clouds
        if(cloudsSpawned)
        {
            Vector3 cloudSpawnPos = new Vector3(Random.Range(-30, -70), Random.Range(18.0f, 23.0f), 0.0f);

            cloudOne = Instantiate(cloudOne, cloudSpawnPos, cloudOne.transform.rotation);
            cloudOne.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f, 0.0f, 0.0f);

            cloudSpawnPos = new Vector3(Random.Range(-30, -70), Random.Range(19.0f, 23.0f), 0.0f);

            cloudTwo = Instantiate(cloudTwo, cloudSpawnPos, cloudTwo.transform.rotation);
            cloudTwo.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f, 0.0f, 0.0f);

            cloudSpawnPos = new Vector3(Random.Range(-30, -70), Random.Range(19.0f, 23.0f), 0.0f);

            cloudThree = Instantiate(cloudThree, cloudSpawnPos, cloudThree.transform.rotation);
            cloudThree.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(5.0f, 0.0f, 0.0f);
        }


        //Spawning enemies
        if(EnemySpawned)
        {
            Vector2 enemySpawnPosLeft = new Vector2(Random.Range(-30, -40), -5.0f);
            Vector2 enemySpawnPosRight = new Vector2(Random.Range(40, 55), -5.0f);

            int leftOrRight = Random.Range(0, 1);

            if( leftOrRight == 0)
            {
                //Left Spawn
                enemyGround = Instantiate(enemyGround, enemySpawnPosLeft, enemyGround.transform.rotation);

            }
            else
            {
                //Right Spawn
                enemyGround = Instantiate(enemyGround, enemySpawnPosRight, enemyGround.transform.rotation);
                enemyGround.gameObject.transform.localScale *= -1;
            }
        }


    }
}
