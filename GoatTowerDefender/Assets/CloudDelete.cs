using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDelete : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= 43)
        {
            gameObject.transform.position = new Vector3(Random.Range(-30, -40), Random.Range(19.0f, 23.5f), 0.0f);
            
        }
    }
}
