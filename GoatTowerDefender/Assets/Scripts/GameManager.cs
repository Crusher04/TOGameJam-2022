using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int waveCounter = 0;

    public GameObject cloudOne;
    public GameObject cloudTwo;
    public GameObject cloudThree;

    public bool cloudsSpawned = false;

    // Start is called before the first frame update
    void Start()
    {

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
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
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
    }
}
