using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public bool attacking = false;
    public HealthBar healthBar;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.gameObject.tag == "EnemyGround")
        {
            Transform currentPos = _collision.gameObject.transform;
            if (currentPos.position.x > 3)
                _collision.transform.position = new Vector3(currentPos.position.x + 2, currentPos.position.y, currentPos.position.z);
            else
                _collision.transform.position = new Vector3(currentPos.position.x - 2, currentPos.position.y, currentPos.position.z);

            TakeDamage(2);
        }

        else if (_collision.gameObject.tag == "AGoat")
        {
            TakeDamage(3);
        }

        else if (_collision.gameObject.tag == "BGoat")
        {
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

}
