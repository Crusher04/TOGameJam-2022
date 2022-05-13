/*
 * Programmer:          Ahmed Hammoud
 * Date:                May, 2022
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //Global Variabels
    public float moveSpeed = 1.0f;

    [SerializeField] private Camera mainCamera;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool FacingLeft = false;
    private float attack = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //Set Animation and Rigidbody 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   
    void FixedUpdate()
    {

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        //Moves Player based on moveSpeed & Fixed Delta Time
        if (attack == 0)
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        
        //Sets Animation for sprite to walk when moving
        anim.SetBool("moveState", moveInput.x != 0);
        anim.SetBool("fireState", attack != 0);

        Flip(mousePosition.x);

    }

    /// <summary>
    /// This function flips the sprites horizontal orientation. 
    /// </summary>
    void Flip(float x)
    {
        if (x < 0 && !FacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            FacingLeft = true;
        }
        else if( x > 0 && FacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            FacingLeft = false;
        }
     
    }

    /// <summary>
    /// This function gets the move value for the function 
    /// </summary>
    /// <param name="value"></param>
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        attack = value.Get<float>();
        StartCoroutine(ExecuteAfterTime(.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if(attack != 0)
        {
            attack = 0;
        }
    }

}
