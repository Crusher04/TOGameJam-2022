using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool hasHit = false;
    public float damage = 5.0f;
    private Collider2D arrowColl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrowColl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    /// <summary>
    /// Our collision detection function
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            StartCoroutine(ExecuteAfterTime(3f));
            Debug.Log("Arrow Collided with Ground");
            hasHit = true;
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            arrowColl.enabled = false;
        }
    }

    /// <summary>
    /// This is a timer function. Executes code after the passed float timer variable
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Destroy(gameObject);
    }
}
