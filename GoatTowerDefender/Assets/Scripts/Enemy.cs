using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed = 2.0f;
    private Rigidbody2D rb;
    public GameObject player;
    private bool hasTurned = false;
    public float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
        RotateTowardsTarget();

        if (health <= 0.0f)
            Destroy(gameObject);

        Debug.Log("Enemy Health = " + health);
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        if (player.transform.position.x - transform.position.x < 1f && hasTurned == false)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            hasTurned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            health -= 1;
            Destroy(collision.gameObject);
        }

        
    }
}
