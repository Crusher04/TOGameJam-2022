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
    public GameObject arrow;
    
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float launchForce = 15;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject Bow;
    
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private bool FacingLeft = false;
    private float attack = 0;
    

    /// <summary>
    /// Our Start Function for this script.
    /// Set our rigidboy and animation components.
    /// </summary>
    void Start()
    {
        //Set Animation and Rigidbody 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Fixed Update Function
    /// </summary>

    void Update()
    {
        //Gets the world position of our mouse cursor
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        //Bow Aiming
        Vector2 bowPos = Bow.transform.position;
        Vector2 bowDirection = mousePosition - bowPos;
        Bow.transform.right = bowDirection;
    }

    void FixedUpdate()
    {
        //Gets the world position of our mouse cursor
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        //Moves Player based on moveSpeed & Fixed Delta Time
        if (attack == 0)
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        
        //Sets Animation for sprite to walk when moving
        anim.SetBool("moveState", moveInput.x != 0);
        anim.SetBool("fireState", attack != 0);
        
        //Flips our player sprite to orientate to where the mouse is
        Flip(mousePosition.x);

    }

    /// <summary>
    /// This function flips the sprites horizontal orientation. 
    /// </summary>
    void Flip(float x)
    {

        float playerPos = x - rb.position.x;

        if (playerPos < 0.0f && !FacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            FacingLeft = true;

            Bow.transform.localScale *= -1;
        }
        else if(playerPos > 0.0f && FacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            FacingLeft = false;
            Bow.transform.localScale *= -1;
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

    /// <summary>
    /// This function gets the attack value when the mouse left button is pressed
    /// </summary>
    /// <param name="value"></param>
    void OnFire(InputValue value)
    {
        if (attack == 0)
            Shoot();
        attack = value.Get<float>();
        StartCoroutine(ExecuteAfterTime(.5f));
        
    }

    /// <summary>
    /// Our collision detection function
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        
        if(!FacingLeft)
            newArrow.GetComponent<Rigidbody2D>().velocity = Bow.transform.right * launchForce;
        else
            newArrow.GetComponent<Rigidbody2D>().velocity = Bow.transform.right * (launchForce);
        
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
        if(attack != 0)
        {
            attack = 0;  
        }
    }

}
